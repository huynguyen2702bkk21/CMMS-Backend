using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;

namespace WebAPICHATest.Api.Application.Queries.MaintenanceRequests
{
    public class MaintenanceRequestByIdQuery : PaginatedQuery, IRequest<QueryResult<MaintenanceRequestViewModel>>
    {
        public string MaintenanceRequestId { get; set; }
        public MaintenanceRequestByIdQuery(string? requestId)
        {
            MaintenanceRequestId = requestId;
        }
    }
}
