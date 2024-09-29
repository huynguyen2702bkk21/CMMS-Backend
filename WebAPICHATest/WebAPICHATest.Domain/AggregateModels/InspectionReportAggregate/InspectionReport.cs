using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPICHATest.Domain.AggregateModels.InspectionReportAggregate
{
    public class InspectionReport : Entity, IAggregateRoot
    {
        public string? InspectionReportId { get; set; }
        public string? Name { get; set; }
        public string? Group { get; set; }
        public EPreventiveInspectionStatus? Status { get; set; }
        public bool? IsRequest { get; set; }

        public InspectionReport(string? inspectionReportId, string? name, string? group, EPreventiveInspectionStatus? status, bool? isRequest)
        {
            InspectionReportId = inspectionReportId;
            Name = name;
            Group = group;
            Status = status;
            IsRequest = isRequest;
        }


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private InspectionReport() { }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


        public void Update(string? name, string? group, EPreventiveInspectionStatus? status, bool? isRequest)
        {
            Name = name;
            Group = group;
            Status = status;
            IsRequest = isRequest;
        }

        public enum EPreventiveInspectionStatus
        {
            passed,
            failed,
            uninspectable
        }
    }
}
