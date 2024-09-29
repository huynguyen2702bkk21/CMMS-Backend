using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.ChartObjAggregate;
using WebAPICHATest.Domain.AggregateModels.DefectAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate.MaintenanceResponse;

namespace WebAPICHATest.Domain.AggregateModels.CauseAggregate
{
    public class Cause : Entity, IAggregateRoot
    {
        public string? CauseId { get; set; }
        public string? CauseCode { get; set; }
        public string? CauseName { get; set; }
        public EMaintenanceObject? MaintenanceObject { get; set; }
        public ECauseSeverity? Severity { get; set; }
        public string? Note { get; set; }
        public List<MaintenanceResponse>? MaintenanceResponses { get; set; }
        public enum ESolutionType
        {
            repair,
            replace
        }

        public enum ECauseSeverity
        {
            urgent,
            high,
            normal,
            low
        }

        private Cause()
        {

        }

        public Cause(string? causeId, string? causeCode, string? causeName, EMaintenanceObject? maintenanceObject, ECauseSeverity? severity, string? note)
        {
            CauseId = causeId;
            CauseCode = causeCode;
            CauseName = causeName;
            MaintenanceObject = maintenanceObject;
            Severity = severity;
            Note = note;
        }

        public void Update(string? causeCode, string? causeName, EMaintenanceObject? maintenanceObject, ECauseSeverity? severity, string? note)
        {
            if (causeCode != null)
            {
                CauseCode = causeCode;
            }

            if (causeName != null)
            {
                CauseName = causeName;
            }

            if(maintenanceObject != null)
            {
                MaintenanceObject = maintenanceObject;

            }

            if (severity != null)
            {
                Severity = severity;

            }

            if (note != null)
            {
                Note = note;
            }
        }
    }
}
