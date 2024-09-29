using static WebAPICHATest.Domain.AggregateModels.CauseAggregate.Cause;
using System.Runtime.Serialization;

namespace WebAPICHATest.Api.Application.Commands.Causes
{
    [DataContract]
    public class CreateCauseCommand : IRequest<bool>
    {
        public string CauseName { get; set; }
        public string MaintenanceObject { get; set; }
        public string Severity { get; set; }
        public string Note { get; set; }

        public CreateCauseCommand(string causeName, string maintenanceObject, string severity, string note)
        {
            CauseName = causeName;
            MaintenanceObject = maintenanceObject;
            Severity = severity;
            Note = note;
        }
    }
}
