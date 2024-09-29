using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WebAPICHATest.Domain.AggregateModels.InspectionReportAggregate.InspectionReport;

namespace WebAPICHATest.Domain.AggregateModels.InspectionReportAggregate
{
    public class InspectionReportWithStatusString
    {
        public string? InspectionReportId { get; set; }
        public string? Name { get; set; }
        public string? Group { get; set; }
        public string? Status { get; set; }
        public bool? IsRequest { get; set; }

        public InspectionReportWithStatusString() { }
        public InspectionReportWithStatusString(string? inspectionReportId, string? name, string? group, string? status, bool? isRequest)
        {
            InspectionReportId = inspectionReportId;
            Name = name;
            Group = group;
            Status = status;
            IsRequest = isRequest;
        }
    }
}
