using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.CauseAggregate;
using WebAPICHATest.Domain.AggregateModels.ChartObjAggregate;
using WebAPICHATest.Domain.AggregateModels.CorrectionAggregate;
using WebAPICHATest.Domain.AggregateModels.EquipmentAggregate;
using WebAPICHATest.Domain.AggregateModels.InspectionReportAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.ProductAggregate;
using WebAPICHATest.Domain.ConstantDomain;
using static WebAPICHATest.Domain.AggregateModels.CauseAggregate.Cause;
using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;
using static WebAPICHATest.Domain.AggregateModels.InspectionReportAggregate.InspectionReport;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate.MaintenanceResponse;

namespace WebAPICHATest.Infrastructure.Repositories
{
    public class MaintenanceResponseRepository : BaseRepository, IMaintenanceResponseRepository
    {
        public MaintenanceResponseRepository(ApplicationDbContext context) : base(context)
        {
        }

        public MaintenanceResponse Add(MaintenanceResponse maintenanceResponse)
        {
            if (maintenanceResponse.IsTransient())
            {
                return _context.MaintenanceResponses
                    .Add(maintenanceResponse)
                    .Entity;
            }
            else
            {
                return maintenanceResponse;
            }
        }

        public MaintenanceResponse Update(MaintenanceResponse maintenanceResponse)
        {
            return _context.MaintenanceResponses
                    .Update(maintenanceResponse)
                    .Entity;
        }

        public async Task<MaintenanceResponse?> GetById(string maintenanceResponseId)
        {
            return await _context.MaintenanceResponses
                .Include(x => x.Cause)
                .Include(x => x.Correction)
                .Include(x => x.Materials)
                .ThenInclude(x => x.MaterialInfor)

                .Include(x => x.Equipment)
                .ThenInclude(x => x.Materials)
                .ThenInclude(x => x.MaterialInfor)
                .Include(x => x.Mold)
                .Include(x => x.InspectionReports)
                .FirstOrDefaultAsync(x => x.MaintenanceResponseId == maintenanceResponseId);
        }

        public async Task<List<MaintenanceResponseWithoutEquipmentMold>> GetListByEquipmentId(string equipmentId)
        {
            var responses = await _context.MaintenanceResponses
            .Include(x => x.Cause)
            .ThenInclude(x => x.MaintenanceResponses)
            .Include(x => x.Correction)
            .ThenInclude(x => x.MaintenanceResponses)
            .Include(x => x.Materials)
            .ThenInclude(x => x.MaterialInfor)
            .Include(x => x.ResponsiblePerson)
            .Include(x => x.InspectionReports)
            .Where(x => x.Equipment.EquipmentId == equipmentId)
            .ToListAsync();
            
            var listWithoutEquipment = new List<MaintenanceResponseWithoutEquipmentMold>();
            foreach(MaintenanceResponse response in responses)
            {
                var newResponseWithoutEquipment = new MaintenanceResponseWithoutEquipmentMold();
                newResponseWithoutEquipment.MaintenanceResponseId = response.MaintenanceResponseId;
                List<CauseWithoutMaintenanceResponse>? causeWithoutMaintenanceResponses = new List<CauseWithoutMaintenanceResponse>();
                foreach(Cause? cause in response.Cause)
                {
                    var causeTemp = new CauseWithoutMaintenanceResponse(causeId: cause.CauseId,
                                                                        causeCode: cause.CauseCode,
                                                                        causeName: cause.CauseName,
                                                                        maintenanceObject: Enum.GetName(typeof(EMaintenanceObject), cause.MaintenanceObject),
                                                                        severity: Enum.GetName(typeof(ECauseSeverity), cause.Severity),
                                                                        note: cause.Note);
                    causeWithoutMaintenanceResponses.Add(causeTemp);
                }
                newResponseWithoutEquipment.Cause = causeWithoutMaintenanceResponses;

                List<CorrectionWithoutMaintenanceResponse>? correctionWithoutMaintenanceResponses = new List<CorrectionWithoutMaintenanceResponse>();

                foreach (Correction? correction in response.Correction)
                {
                    var correctionTemp = new CorrectionWithoutMaintenanceResponse(correctionId: correction.CorrectionId,
                                                                                  correctionCode: correction.CorrectionCode,
                                                                                  correctionName: correction.CorrectionName,
                                                                                  correctionType: Enum.GetName(typeof(ESolutionType), correction.CorrectionType),
                                                                                  estProcessTime: correction.EstProcessTime,
                                                                                  note: correction.Note);
                    correctionWithoutMaintenanceResponses.Add(correctionTemp);
                }
                newResponseWithoutEquipment.Correction = correctionWithoutMaintenanceResponses;

                newResponseWithoutEquipment.PlannedStart = response.PlannedStart;
                newResponseWithoutEquipment.PlannedFinish = response.PlannedFinish;
                newResponseWithoutEquipment.EstProcessTime = response.EstProcessTime;
                newResponseWithoutEquipment.ActualStartTime = response.ActualStartTime;
                newResponseWithoutEquipment.ActualFinishTime = response.ActualFinishTime;
                newResponseWithoutEquipment.Status = Enum.GetName(typeof(EMaintenanceStatus), response.Status);
                newResponseWithoutEquipment.CreatedAt = response.CreatedAt;
                newResponseWithoutEquipment.UpdatedAt = response.UpdatedAt;
                newResponseWithoutEquipment.Priority= response.Priority;
                newResponseWithoutEquipment.Problem= response.Problem;
                newResponseWithoutEquipment.Images= response.Images;
                newResponseWithoutEquipment.Sounds= response.Sounds;
                newResponseWithoutEquipment.Materials= response.Materials;
                newResponseWithoutEquipment.Note= response.Note;
                newResponseWithoutEquipment.Code= response.Code;
                newResponseWithoutEquipment.MaintenanceObject = Enum.GetName(typeof(EMaintenanceObject), response.MaintenanceObject);
                newResponseWithoutEquipment.DueDate = response.DueDate;
                newResponseWithoutEquipment.Type = Enum.GetName(typeof(EMaintenanceType), response.Type);
                var listInspectionReportStatusString = new List<InspectionReportWithStatusString>();
                if (response.InspectionReports != null)
                {
                    foreach (var report in response.InspectionReports)
                    {
                        var newInspectionReportStatusString = new InspectionReportWithStatusString(inspectionReportId: report.InspectionReportId,
                                                                                                   name: report.Name,
                                                                                                   group: report.Group,
                                                                                                   status: Enum.GetName(typeof(EPreventiveInspectionStatus), report.Status),
                                                                                                   isRequest: report.IsRequest);
                        listInspectionReportStatusString.Add(newInspectionReportStatusString);
                    }
                }
                newResponseWithoutEquipment.InspectionReports = listInspectionReportStatusString;
                listWithoutEquipment.Add(newResponseWithoutEquipment);
            }

            return listWithoutEquipment;
        }

        public async Task<List<MaintenanceResponseWithoutEquipmentMold>> GetListByMoldId(string moldId)
        {
            var responses = await _context.MaintenanceResponses
                                        .Include(x => x.Cause)
                                        .ThenInclude(x => x.MaintenanceResponses)
                                        .Include(x => x.Correction)
                                        .ThenInclude(x => x.MaintenanceResponses)
                                        .Include(x => x.Materials)
                                        .ThenInclude(x => x.MaterialInfor)
                                        .Include(x => x.ResponsiblePerson)
                                        .Include(x => x.InspectionReports)
                                        .Where(x => x.Mold.MoldId == moldId).ToListAsync();

            var listWithoutEquipment = new List<MaintenanceResponseWithoutEquipmentMold>();
            foreach (MaintenanceResponse response in responses)
            {
                var newResponseWithoutEquipment = new MaintenanceResponseWithoutEquipmentMold();
                newResponseWithoutEquipment.MaintenanceResponseId = response.MaintenanceResponseId;
                List<CauseWithoutMaintenanceResponse>? causeWithoutMaintenanceResponses = new List<CauseWithoutMaintenanceResponse>();
                foreach (Cause? cause in response.Cause)
                {
                    var causeTemp = new CauseWithoutMaintenanceResponse(causeId: cause.CauseId,
                                                                        causeCode: cause.CauseCode,
                                                                        causeName: cause.CauseName,
                                                                        maintenanceObject: Enum.GetName(typeof(EMaintenanceObject), cause.MaintenanceObject),
                                                                        severity: Enum.GetName(typeof(ECauseSeverity), cause.Severity),
                                                                        note: cause.Note);
                    causeWithoutMaintenanceResponses.Add(causeTemp);
                }
                newResponseWithoutEquipment.Cause = causeWithoutMaintenanceResponses;

                List<CorrectionWithoutMaintenanceResponse>? correctionWithoutMaintenanceResponses = new List<CorrectionWithoutMaintenanceResponse>();

                foreach (Correction? correction in response.Correction)
                {
                    var correctionTemp = new CorrectionWithoutMaintenanceResponse(correctionId: correction.CorrectionId,
                                                                                  correctionCode: correction.CorrectionCode,
                                                                                  correctionName: correction.CorrectionName,
                                                                                  correctionType: Enum.GetName(typeof(ESolutionType), correction.CorrectionType),
                                                                                  estProcessTime: correction.EstProcessTime,
                                                                                  note: correction.Note);
                    correctionWithoutMaintenanceResponses.Add(correctionTemp);
                }
                newResponseWithoutEquipment.Correction = correctionWithoutMaintenanceResponses;

                newResponseWithoutEquipment.PlannedStart = response.PlannedStart;
                newResponseWithoutEquipment.PlannedFinish = response.PlannedFinish;
                newResponseWithoutEquipment.EstProcessTime = response.EstProcessTime;
                newResponseWithoutEquipment.ActualStartTime = response.ActualStartTime;
                newResponseWithoutEquipment.ActualFinishTime = response.ActualFinishTime;
                newResponseWithoutEquipment.Status = Enum.GetName(typeof(EMaintenanceStatus), response.Status);
                newResponseWithoutEquipment.CreatedAt = response.CreatedAt;
                newResponseWithoutEquipment.UpdatedAt = response.UpdatedAt;
                newResponseWithoutEquipment.Priority = response.Priority;
                newResponseWithoutEquipment.Problem = response.Problem;
                newResponseWithoutEquipment.Images = response.Images;
                newResponseWithoutEquipment.Sounds = response.Sounds;
                newResponseWithoutEquipment.Materials = response.Materials;
                newResponseWithoutEquipment.Note = response.Note;
                newResponseWithoutEquipment.Code = response.Code;
                newResponseWithoutEquipment.MaintenanceObject = Enum.GetName(typeof(EMaintenanceObject), response.MaintenanceObject);
                newResponseWithoutEquipment.DueDate = response.DueDate;
                newResponseWithoutEquipment.Type = Enum.GetName(typeof(EMaintenanceType), response.Type);
                var listInspectionReportStatusString = new List<InspectionReportWithStatusString>();
                if (response.InspectionReports != null)
                {
                    foreach (var report in response.InspectionReports)
                    {
                        var newInspectionReportStatusString = new InspectionReportWithStatusString(inspectionReportId: report.InspectionReportId,
                                                                                                   name: report.Name,
                                                                                                   group: report.Group,
                                                                                                   status: Enum.GetName(typeof(EPreventiveInspectionStatus), report.Status),
                                                                                                   isRequest: report.IsRequest);
                        listInspectionReportStatusString.Add(newInspectionReportStatusString);
                    }
                }
                newResponseWithoutEquipment.InspectionReports = listInspectionReportStatusString;
                listWithoutEquipment.Add(newResponseWithoutEquipment);
            }
            return listWithoutEquipment;
        }

        public List<ChartObj> ConvertFromCauseToChartObj(List<MaintenanceResponseWithoutEquipmentMold> listResponse)
        {
            var listError = new List<ChartObj>();
            var listCause = new List<CauseWithoutMaintenanceResponse>();
            foreach (MaintenanceResponseWithoutEquipmentMold response in listResponse)
            {
                if (response.Cause != null)
                {
                    foreach(CauseWithoutMaintenanceResponse cause in response.Cause)
                    {
                        listCause.Add(cause);
                    }
                }
            }

            var listCauseTemp = listCause.Distinct().ToList();
            foreach (CauseWithoutMaintenanceResponse causeTemp in listCauseTemp)
            {
                var error = new ChartObj(causeTemp.CauseName);
                int i = 0;
                foreach (CauseWithoutMaintenanceResponse cause in listCause)
                {
                    if (cause == causeTemp)
                        i++;
                }
                error.Value = i;
                listError.Add(error);
            }

            return listError;
        }

        public async Task<List<MaintenanceResponse>>? GetAll()
        {
            return await _context.MaintenanceResponses
                .Include(x => x.Cause)
                .Include(x => x.Correction)
                .Include(x => x.Materials)
                .ThenInclude(x => x.MaterialInfor)

                .Include(x => x.Equipment)
                .ThenInclude(x => x.Materials)
                .ThenInclude(x => x.MaterialInfor)
                .Include(x => x.InspectionReports)
                .AsNoTracking().ToListAsync();
        }
    }
}
