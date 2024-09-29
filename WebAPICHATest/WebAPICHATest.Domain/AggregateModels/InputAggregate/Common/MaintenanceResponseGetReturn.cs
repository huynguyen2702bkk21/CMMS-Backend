using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.CauseAggregate;
using WebAPICHATest.Domain.AggregateModels.CorrectionAggregate;
using WebAPICHATest.Domain.AggregateModels.EquipmentAggregate;
using WebAPICHATest.Domain.AggregateModels.InspectionReportAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.MoldAggregate;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate.MaintenanceResponse;

namespace WebAPICHATest.Domain.AggregateModels.InputAggregate.Common
{
    public class MaintenanceResponseGetReturn
    {
        public string? MaintenanceResponseId { get; set; }
        public List<Cause>? Cause { get; set; }
        public List<Correction>? Correction { get; set; }
        public DateTime? PlannedStart { get; set; }
        public DateTime? PlannedFinish { get; set; }
        public int? EstProcessTime { get; set; }
        public DateTime? ActualStartTime { get; set; }
        public DateTime? ActualFinishTime { get; set; }
        public string? Status { get; set; } //Enum
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Person? ResponsiblePerson { get; set; }
        public int? Priority { get; set; }
        public string? Problem { get; set; }
        public List<string>? Images { get; set; }
        public List<string>? Sounds { get; set; }
        public List<Material>? Materials { get; set; }
        public string? Code { get; set; }
        public string? Note { get; set; }
        public MaintenanceRequest? Request { get; set; }
        public string? MaintenanceObject { get; set; }
        public Equipment? Equipment { get; set; }
        public Mold? Mold { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Type { get; set; }
        public List<InspectionReportWithStatusString>? InspectionReports { get; set; }

        public MaintenanceResponseGetReturn()
        {

        }

        public MaintenanceResponseGetReturn(string? maintenanceResponseId, List<Cause>? cause, List<Correction>? correction, DateTime? plannedStart, DateTime? plannedFinish, int? estProcessTime, DateTime? actualStartTime, DateTime? actualFinishTime, string? status, DateTime? createdAt, DateTime? updatedAt, Person? responsiblePerson, int? priority, string? problem, List<string>? images, List<string>? sounds, List<Material>? materials, string? code, string? note, MaintenanceRequest? request, string? maintenanceObject, Equipment? equipment, Mold? mold, DateTime? dueDate, string? type, List<InspectionReportWithStatusString>? inspectionReports)
        {
            MaintenanceResponseId = maintenanceResponseId;
            Cause = cause;
            Correction = correction;
            PlannedStart = plannedStart;
            PlannedFinish = plannedFinish;
            EstProcessTime = estProcessTime;
            ActualStartTime = actualStartTime;
            ActualFinishTime = actualFinishTime;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            ResponsiblePerson = responsiblePerson;
            Priority = priority;
            Problem = problem;
            Images = images;
            Sounds = sounds;
            Materials = materials;
            Code = code;
            Note = note;
            Request = request;
            MaintenanceObject = maintenanceObject;
            Equipment = equipment;
            Mold = mold;
            DueDate = dueDate;
            Type = type;
            InspectionReports = inspectionReports;
        }

        public static List<MaintenanceResponseGetReturn> ReturnListMainetanceResponse(List<JobInfor> newListJobInfor, List<Equipment>? listEquipment, List<Mold>? listMold, List<Person>? listPerson, bool? rejected)
        {
            List<MaintenanceResponseGetReturn> maintenanceResponses = new List<MaintenanceResponseGetReturn>();
            foreach (JobInfor workInfor in newListJobInfor)
            {
                var newMaintenanceResponseId = Guid.NewGuid().ToString();
                var plannedStart = workInfor.startPlannedDate;
                var plannedFinish = workInfor.endPlannedDate;
                var estProcessTime = workInfor.estProcessTime;

                Person? responsiblePerson = null;
                foreach (Person person in listPerson)
                {
                    if (person.PersonId == workInfor.technician)
                    {
                        responsiblePerson = person;
                        break;
                    }
                }

                var priority = workInfor.priority;
                var problem = workInfor.work;
                var dueDate = workInfor.dueDate;

                Equipment? equipment = null;
                Mold? mold = null;
                EMaintenanceObject? maintenanceObject = null;

                MaintenanceResponseGetReturn? maintenanceResponse = null;
                foreach (Equipment equipmentTemp in listEquipment)
                {
                    if (equipmentTemp.Code == workInfor.device)
                    {
                        maintenanceObject = EMaintenanceObject.equipment;
                        equipment = equipmentTemp;
                        mold = null;
                    }
                }


                foreach (Mold moldTemp in listMold)
                {
                    if (moldTemp.Code == workInfor.device)
                    {
                        maintenanceObject = EMaintenanceObject.mold;
                        equipment = null;
                        mold = moldTemp;
                    }
                }

                var status = EMaintenanceStatus.assigned;
                EMaintenanceType type;
                if (workInfor.work == "Kiểm tra tổng quát")
                {
                    type = EMaintenanceType.preventiveInspection;
                }
                else
                {
                    type = EMaintenanceType.preventive;
                }

                string? code = null;
                if (rejected != null)
                {
                    code = workInfor.ReasonFail;
                }

                maintenanceResponse = new MaintenanceResponseGetReturn(maintenanceResponseId: newMaintenanceResponseId,
                                                                       cause: null,
                                                                       correction: null,
                                                                       plannedStart: plannedStart,
                                                                       plannedFinish: plannedFinish,
                                                                       estProcessTime: estProcessTime,
                                                                       actualStartTime: null,
                                                                       actualFinishTime: null,
                                                                       status: Enum.GetName(typeof(EMaintenanceStatus), status),
                                                                       createdAt: DateTime.UtcNow,
                                                                       updatedAt: DateTime.UtcNow,
                                                                       responsiblePerson: responsiblePerson,
                                                                       priority: priority,
                                                                       problem: problem,
                                                                       images: null,
                                                                       sounds: null,
                                                                       materials: null,
                                                                       code: code,
                                                                       note: null,
                                                                       request: null,
                                                                       maintenanceObject: Enum.GetName(typeof(EMaintenanceObject), maintenanceObject),
                                                                       equipment: equipment,
                                                                       mold: mold,
                                                                       dueDate: dueDate,
                                                                       type: Enum.GetName(typeof(EMaintenanceType), type),
                                                                       inspectionReports: null);

                maintenanceResponses.Add(maintenanceResponse);
            }

            return maintenanceResponses;
        }
    }
}
