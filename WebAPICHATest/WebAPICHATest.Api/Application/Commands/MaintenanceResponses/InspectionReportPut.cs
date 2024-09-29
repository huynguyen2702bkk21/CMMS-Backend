using static WebAPICHATest.Domain.AggregateModels.InspectionReportAggregate.InspectionReport;

namespace WebAPICHATest.Api.Application.Commands.MaintenanceResponses
{
    public class InspectionReportPut
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public string Status { get; set; }
        public bool IsRequest { get; set; }

        public InspectionReportPut(string name, string group, string status, bool isRequest)
        {
            Name = name;
            Group = group;
            Status = status;
            IsRequest = isRequest;
        }
    }
}
