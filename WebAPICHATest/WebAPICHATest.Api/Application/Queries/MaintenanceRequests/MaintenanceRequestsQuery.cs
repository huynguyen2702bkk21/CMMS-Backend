using WebAPICHATest.Api.Application.Queries.MaintenanceRequests;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;

namespace WebAPICHATest.Api.Application.Queries.MaintenanceRequests
{
    public class MaintenanceRequestsQuery : IRequest<List<MaintenanceRequestViewModel>>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Status { get; set; }
        public MaintenanceRequestsQuery()
        {

        }

        public MaintenanceRequestsQuery(DateTime? startDate, DateTime? endDate, string? status)
        {
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
        }
    }
}
