using WebAPICHATest.Api.Application.Queries.MaintenanceResponses;

namespace WebAPICHATest.Api.Application.Queries.MaintenanceResponses
{
    public class MaintenanceResponsesQuery : IRequest<List<MaintenanceResponseViewModel>>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Status { get; set; }

        public MaintenanceResponsesQuery() { }
        public MaintenanceResponsesQuery(DateTime? startDate, DateTime? endDate, string? status)
        {
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
        }
    }
}
