using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;

namespace WebAPICHATest.Api.Application.Commands.MaintenanceRequests
{
    public class UpdateMaintenanceRequestViewModel
    {
        public string? MaintenanceRequestId { get; set; }
        public string? Code { get; set; }
        public string? Problem { get; set; }
        public DateTime? RequestedCompletionDate { get; set; }
        public int? RequestedPriority { get; set; }
        public string? Requester { get; set; }
        public string? Status { get; set; } //Enum
        public string? Reviewer { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public string? Type { get; set; } //Enum
        public string? MaintenanceObject { get; set; }
        public string? Equipment { get; set; }
        public string? Mold { get; set; }
        public List<string>? Images { get; set; }
        public List<string>? Sounds { get; set; }
        public string? ResponsiblePerson { get; set; }
        public int? EstProcessingTime { get; set; }
        public DateTime? PlannedStart { get; set; }

        private UpdateMaintenanceRequestViewModel()
        {

        }

        public UpdateMaintenanceRequestViewModel(string? maintenanceRequestId, string? code, string? problem, DateTime? requestedCompletionDate, int? requestedPriority, string? requester, string? status, string? reviewer, DateTime? submissionDate, string? type, string? maintenanceObject, string? equipment, string? mold, List<string>? images, List<string>? sounds, string? responsiblePerson, int? estProcessingTime, DateTime? plannedStart)
        {
            MaintenanceRequestId = maintenanceRequestId;
            Code = code;
            Problem = problem;
            RequestedCompletionDate = requestedCompletionDate;
            RequestedPriority = requestedPriority;
            Requester = requester;
            Status = status;
            Reviewer = reviewer;
            SubmissionDate = submissionDate;
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
