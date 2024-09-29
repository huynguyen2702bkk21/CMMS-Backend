using WebAPICHATest.Api.Application.Queries.MaintenanceResponses;

namespace WebAPICHATest.Api.Application.Queries.MaintenanceResponses
{
    public class MaintenanceResponseByIdQuery : PaginatedQuery, IRequest<QueryResult<MaintenanceResponseViewModel>>
    {
        public string MaintenanceResponseId { get; set; }
        public MaintenanceResponseByIdQuery(string? requestId)
        {
            MaintenanceResponseId = requestId;
        }
    }
}
