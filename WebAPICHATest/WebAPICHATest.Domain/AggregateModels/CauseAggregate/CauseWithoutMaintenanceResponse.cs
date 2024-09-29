using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WebAPICHATest.Domain.AggregateModels.CauseAggregate.Cause;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate.MaintenanceResponse;

namespace WebAPICHATest.Domain.AggregateModels.CauseAggregate
{
    public class CauseWithoutMaintenanceResponse
    {
        public string? CauseId { get; set; }
        public string? CauseCode { get; set; }
        public string? CauseName { get; set; }
        public string? MaintenanceObject { get; set; }
        public string? Severity { get; set; }
        public string? Note { get; set; }

        public CauseWithoutMaintenanceResponse(string? causeId, string? causeCode, string? causeName, string? maintenanceObject, string? severity, string? note)
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
