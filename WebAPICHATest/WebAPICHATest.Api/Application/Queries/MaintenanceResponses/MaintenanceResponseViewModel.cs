using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;
using WebAPICHATest.Domain.AggregateModels.CauseAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate.MaintenanceResponse;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Domain.AggregateModels.SoundAggregate;
using WebAPICHATest.Domain.AggregateModels.CorrectionAggregate;
using WebAPICHATest.Domain.AggregateModels.MoldAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate;
using WebAPICHATest.Domain.AggregateModels.InspectionReportAggregate;

namespace WebAPICHATest.Api.Application.Queries.MaintenanceResponses
{
    public class MaintenanceResponseViewModel
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

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private MaintenanceResponseViewModel() { }

        public MaintenanceResponseViewModel(string? maintenanceResponseId, List<Cause>? cause, List<Correction>? correction, DateTime? plannedStart, DateTime? plannedFinish, int? estProcessTime, DateTime? actualStartTime, DateTime? actualFinishTime, string? status, DateTime? createdAt, DateTime? updatedAt, Person? responsiblePerson, int? priority, string? problem, List<string>? images, List<string>? sounds, List<Material>? materials, string? code, string? note, MaintenanceRequest? request, string? maintenanceObject, Equipment? equipment, Mold? mold, DateTime? dueDate, string? type, List<InspectionReportWithStatusString>? inspectionReports)
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


#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
