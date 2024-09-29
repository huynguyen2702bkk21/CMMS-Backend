using static WebAPICHATest.Domain.AggregateModels.CauseAggregate.Cause;
using System.Runtime.Serialization;

namespace WebAPICHATest.Api.Application.Commands.Causes
{
    [DataContract]
    public class UpdateCauseCommand : IRequest<bool>
    {
        public string? CauseId { get; set; }
        public string? CauseCode { get; set; }
        public string? CauseName { get; set; }
        public string? MaintenanceObject { get; set; }
        public string? Severity { get; set; }
        public string? Note { get; set; }

        public UpdateCauseCommand(string? causeId, string? causeCode, string? causeName, string? maintenanceObject, string? severity, string? note)
        {
            CauseId = causeId;
            CauseCode = causeCode;
            CauseName = causeName;
            MaintenanceObject = maintenanceObject;
            Severity = severity;
            Note = note;
        }
    }
}
