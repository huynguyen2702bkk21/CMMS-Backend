using WebAPICHATest.Api.Application.Queries.Causes;

namespace WebAPICHATest.Api.Application.Queries.Causes
{
    public class CauseByIdQuery : PaginatedQuery, IRequest<QueryResult<CauseViewModel>>
    {
        public string? CauseId { get; set; }

        public CauseByIdQuery(string? equipmentId)
        {
            CauseId = equipmentId;
        }
    }
}
