using WebAPICHATest.Domain.AggregateModels.CauseAggregate;
using WebAPICHATest.Domain.AggregateModels.CorrectionAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.MoldAggregate;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate.MaintenanceResponse;
using WebAPICHATest.Domain.AggregateModels.SoundAggregate;

namespace WebAPICHATest.Api.Application.Queries.MaintenanceRequests
{
    public class MaintenanceRequestGetViewModel
    {
        public string? MaintenanceRequestId { get; set; }
        public string? Code { get; set; }
        public string? Problem { get; set; }
        public DateTime? RequestedCompletionDate { get; set; }
        public int? RequestedPriority { get; set; }
        public Person? Requester { get; set; }
        public string? Status { get; set; } //Enum
        public Person? Reviewer { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? Type { get; set; } //Enum
        public string? MaintenanceObject { get; set; }
        public Equipment? Equipment { get; set; }
        public Mold? Mold { get; set; }
        public List<string>? Images { get; set; }
        public List<string>? Sounds { get; set; }
        public Person? ResponsiblePerson { get; set; }
        public int? EstProcessingTime { get; set; }
        public DateTime? PlannedStart { get; set; }

        private MaintenanceRequestGetViewModel()
        {

        }

        public MaintenanceRequestGetViewModel(string? maintenanceRequestId)
        {
            MaintenanceRequestId = maintenanceRequestId;
        }

        public MaintenanceRequestGetViewModel(string? maintenanceRequestId, string? code, string? problem, DateTime? requestedCompletionDate, int? requestedPriority, Person? requester, string? status, Person? reviewer, DateTime? submissionDate, DateTime? createdAt, DateTime? updatedAt, string? type, string? maintenanceObject, Equipment? equipment, Mold? mold, List<string>? images, List<string>? sounds, Person? responsiblePerson, int? estProcessingTime, DateTime? plannedStart) : this(maintenanceRequestId)
        {
            Code = code;
            Problem = problem;
            RequestedCompletionDate = requestedCompletionDate;
            RequestedPriority = requestedPriority;
            Requester = requester;
            Status = status;
            Reviewer = reviewer;
            SubmissionDate = submissionDate;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Type = type;
            MaintenanceObject = maintenanceObject;
            Equipment = equipment;
            Mold = mold;
            Images = images;
            Sounds = sounds;
            ResponsiblePerson = responsiblePerson;
            EstProcessingTime = estProcessingTime;
            PlannedStart = plannedStart;
        }
    }
}
