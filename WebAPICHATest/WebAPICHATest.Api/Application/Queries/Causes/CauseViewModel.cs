using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using static WebAPICHATest.Domain.AggregateModels.CauseAggregate.Cause;

namespace WebAPICHATest.Api.Application.Queries.Causes
{
    public class CauseViewModel
    {
        public string? CauseId { get; set; }
        public string? CauseCode { get; set; }
        public string? CauseName { get; set; }
        public string? EquipmentType { get; set; }
        public string? Severity { get; set; }
        public string? Note { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private CauseViewModel() { }

        public CauseViewModel(string? causeId, string? causeCode, string? causeName, string? equipmentType, string? severity, string? note)
        {
            CauseId = causeId;
            CauseCode = causeCode;
            CauseName = causeName;
            EquipmentType = equipmentType;
            Severity = severity;
            Note = note;
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
