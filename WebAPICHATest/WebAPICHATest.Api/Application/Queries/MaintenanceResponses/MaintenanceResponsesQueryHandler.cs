using System;
using System.Globalization;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Api.Application.Queries.MaintenanceResponses;
using WebAPICHATest.Domain.AggregateModels.CauseAggregate;
using WebAPICHATest.Domain.AggregateModels.CorrectionAggregate;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Domain.AggregateModels.InspectionReportAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.NotificationAggregate;
using WebAPICHATest.Domain.AggregateModels.SoundAggregate;
using WebAPICHATest.Infrastructure;
using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;
using static WebAPICHATest.Domain.AggregateModels.InspectionReportAggregate.InspectionReport;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate.MaintenanceResponse;
using static WebAPICHATest.Domain.AggregateModels.MaterialRequestAggregate.MaterialRequest;

namespace WebAPICHATest.Api.Application.Queries.MaintenanceResponses
{
    public class MaintenanceResponsesQueryHandler : IRequestHandler<MaintenanceResponsesQuery, List<MaintenanceResponseViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICauseRepository _causeRepository;
        private readonly ICorrectionRepository _correctionRepository;
        private readonly IMaintenanceRequestRepository _maintenanceRequestRepository;

        public MaintenanceResponsesQueryHandler(ApplicationDbContext context, IMapper mapper, 
                                                ICauseRepository causeRepository, 
                                                ICorrectionRepository correctionRepository,
                                                IMaintenanceRequestRepository maintenanceRequestRepository)
        {
            _context = context;
            _mapper = mapper;
            _causeRepository = causeRepository;
            _correctionRepository = correctionRepository;
            _maintenanceRequestRepository = maintenanceRequestRepository;
        }

        public async Task<List<MaintenanceResponseViewModel>> Handle(MaintenanceResponsesQuery request, CancellationToken cancellationToken)
        {
            EMaintenanceStatus status;
            Enum.TryParse<EMaintenanceStatus>(request.Status, out status);

            DateTime? startDateLocal = DateTime.ParseExact("01/01/1970", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime? endDateLocal = DateTime.ParseExact("01/01/2100", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if (request.StartDate is not null)
            {
                startDateLocal = request.StartDate;
            }

            if (request.EndDate is not null)
            {
                endDateLocal = request.EndDate;
            }

            var result = new List<MaintenanceResponse>();
            if (request.Status != null)
            {
                result = await _context.MaintenanceResponses
                .Include(x => x.Cause)
                .Include(x => x.Correction)
                .Include(x => x.Materials)
                .ThenInclude(x => x.MaterialInfor)
                .Include(x => x.ResponsiblePerson)
                .Include(x => x.Request)
                .Include(x => x.Equipment)
                .ThenInclude(x => x.MTBF)
                .ThenInclude(x => x.History)

                .Include(x => x.Equipment)
                .ThenInclude(x => x.MTTF)
                .ThenInclude(x => x.History)

                .Include(x => x.Equipment)
                .ThenInclude(x => x.OEE)
                .ThenInclude(x => x.History)

                .Include(x => x.Mold)
                .Include(x => x.InspectionReports)
                .Where(x => x.CreatedAt >= startDateLocal && x.CreatedAt <= endDateLocal)
                .Where(x => x.Status == status)
                .OrderByDescending(x => x.Status != EMaintenanceStatus.completed)
                .ThenByDescending(x => x.CreatedAt)
                .ToListAsync();
            }
            else
            {
                result = await _context.MaintenanceResponses
                .Include(x => x.Cause)
                .Include(x => x.Correction)
                .Include(x => x.Materials)
                .ThenInclude(x => x.MaterialInfor)
                .Include(x => x.ResponsiblePerson)
                .Include(x => x.Request)
                .Include(x => x.Equipment)
                .ThenInclude(x => x.MTBF)
                .ThenInclude(x => x.History)

                .Include(x => x.Equipment)
                .ThenInclude(x => x.MTTF)
                .ThenInclude(x => x.History)

                .Include(x => x.Equipment)
                .ThenInclude(x => x.OEE)
                .ThenInclude(x => x.History)

                .Include(x => x.Mold)
                .Include(x => x.InspectionReports)
                .Where(x => x.CreatedAt >= startDateLocal && x.CreatedAt <= endDateLocal)
                .OrderByDescending(x => x.Status != EMaintenanceStatus.completed)
                .ThenByDescending(x => x.CreatedAt)
                .ToListAsync();
            }

            var listGetViewModel = new List<MaintenanceResponseGetViewModel>();
            foreach (MaintenanceResponse response in result)
            {
                var newGetViewModel = new MaintenanceResponseGetViewModel(response.MaintenanceResponseId);
                var listCause = new List<Cause>();
                foreach(Cause cause in response.Cause)
                {
                    var newCause = await _causeRepository.GetById(cause.CauseId) ?? throw new NotFoundException();
                    listCause.Add(newCause);
                }

                newGetViewModel.Cause = listCause;
                foreach (Cause item in newGetViewModel.Cause)
                {
                    item.MaintenanceResponses = null;
                    item.MaintenanceObject = null;
                    item.Severity = null;
                }
                var listCorrection = new List<Correction>();
                foreach (Correction correction in response.Correction)
                {
                    var newCorrection = await _correctionRepository.GetById(correction.CorrectionId) ?? throw new NotFoundException();
                    listCorrection.Add(newCorrection);
                }
                newGetViewModel.Correction = listCorrection;
                foreach(Correction item in newGetViewModel.Correction)
                {
                    item.MaintenanceResponses = null;
                    item.CorrectionType = null;
                }

                newGetViewModel.PlannedStart = response.PlannedStart;
                newGetViewModel.PlannedFinish = response.PlannedFinish;
                newGetViewModel.EstProcessTime = response.EstProcessTime;
                newGetViewModel.ActualStartTime = response.ActualStartTime;
                newGetViewModel.ActualFinishTime = response.ActualFinishTime;
                newGetViewModel.Status = Enum.GetName(typeof(EMaintenanceStatus), response.Status);
                newGetViewModel.CreatedAt = response.CreatedAt;
                newGetViewModel.UpdatedAt = response.UpdatedAt;
                newGetViewModel.ResponsiblePerson = response.ResponsiblePerson;
                newGetViewModel.ResponsiblePerson.ScheduleWorkingTimes = null;
                newGetViewModel.Priority = response.Priority;
                newGetViewModel.Problem = response.Problem;

                List<string>? listImageString = null;
                if (string.IsNullOrEmpty(response.Images) == false)
                {
                    listImageString = response.Images.Split("|").ToList();
                    listImageString.RemoveAt(listImageString.Count - 1);
                }
                newGetViewModel.Images = listImageString;

                List<string>? listSoundString = null;
                if (string.IsNullOrEmpty(response.Sounds) == false)
                {
                    listSoundString = response.Sounds.Split("|").ToList();
                    listSoundString.RemoveAt(listSoundString.Count - 1);
                }
                newGetViewModel.Sounds = listSoundString;

                newGetViewModel.Materials = response.Materials;
                if (response.Materials != null)
                {
                    foreach(Material material in newGetViewModel.Materials)
                    {
                        material.Status = null;
                    }
                }

                newGetViewModel.Code = response.Code;
                newGetViewModel.Note = response.Note;
                if (response.Request == null)
                {
                    newGetViewModel.Request = null;
                }
                else
                {
                    newGetViewModel.Request = response.Request;
                }

                newGetViewModel.Request.Status = null;
                newGetViewModel.Request.Type = null;
                newGetViewModel.Request.MaintenanceObject = null;
                if (newGetViewModel.Request.Equipment != null)
                {
                    newGetViewModel.Request.Equipment.Type = null;
                    newGetViewModel.Request.Equipment.Status = null;
                }

                if (newGetViewModel.Request.Mold != null)
                {
                    newGetViewModel.Request.Mold.Status = null;
                }

                newGetViewModel.MaintenanceObject = Enum.GetName(typeof(EMaintenanceObject), response.MaintenanceObject);
                newGetViewModel.Equipment = response.Equipment;
                if (newGetViewModel.Equipment != null)
                {
                    newGetViewModel.Equipment.Type = null;
                    newGetViewModel.Equipment.Status = null;
                }

                newGetViewModel.Mold = response.Mold;
                if (newGetViewModel.Mold != null)
                {
                    newGetViewModel.Mold.Status = null;

                }

                newGetViewModel.DueDate = response.DueDate;
                newGetViewModel.Type = Enum.GetName(typeof(EMaintenanceType), response.Type);
                
                var listInspectionReportStatusString = new List<InspectionReportWithStatusString>();
                if (response.InspectionReports != null)
                {
                    foreach(var report in response.InspectionReports)
                    {
                        var newInspectionReportStatusString = new InspectionReportWithStatusString(inspectionReportId: report.InspectionReportId,
                                                                                                   name: report.Name,
                                                                                                   group: report.Group,
                                                                                                   status: Enum.GetName(typeof(EPreventiveInspectionStatus), report.Status),
                                                                                                   isRequest: report.IsRequest);
                        listInspectionReportStatusString.Add(newInspectionReportStatusString);
                    }
                }
                newGetViewModel.InspectionReports = listInspectionReportStatusString;

                listGetViewModel.Add(newGetViewModel);
            }

            return _mapper.Map<List<MaintenanceResponseGetViewModel>, List<MaintenanceResponseViewModel>>(listGetViewModel);
        }
    }
}
