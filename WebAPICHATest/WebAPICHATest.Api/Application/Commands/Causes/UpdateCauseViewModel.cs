using static WebAPICHATest.Domain.AggregateModels.CauseAggregate.Cause;

namespace WebAPICHATest.Api.Application.Commands.Causes
{
    public class UpdateCauseViewModel
    {
        public string? CauseId { get; set; }
        public string? CauseCode { get; set; }
        public string? CauseName { get; set; }
        public string? MaintenanceObject { get; set; }
        public string? Severity { get; set; }
        public string? Note { get; set; }

        public UpdateCauseViewModel(string? causeId, string? causeCode, string? causeName, string? maintenanceObject, string? severity, string? note)
        {
            CauseId = causeId;
            CauseCode = causeCode;
            CauseName = causeName;
            MaintenanceObject = maintenanceObject;
            Severity = severity;
            Note = note;
        }

        private UpdateCauseViewModel()
        {

        }
    }
}
