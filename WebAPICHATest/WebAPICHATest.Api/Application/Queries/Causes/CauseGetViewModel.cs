using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;

namespace WebAPICHATest.Api.Application.Queries.Causes
{
    public class CauseGetViewModel
    {
        public string? CauseId { get; set; }
        public string? CauseCode { get; set; }
        public string? CauseName { get; set; }
        public string? EquipmentType { get; set; }
        public string? Severity { get; set; }
        public string? Note { get; set; }
        private CauseGetViewModel() { }

        public CauseGetViewModel(string? causeId)
        {
            CauseId = causeId;
        }

        public CauseGetViewModel(string? causeId, string? causeCode, string? causeName, string? equipmentType, string? severity, string? note)
        {
            CauseId = causeId;
            CauseCode = causeCode;
            CauseName = causeName;
            EquipmentType = equipmentType;
            Severity = severity;
            Note = note;
        }
    }
}
