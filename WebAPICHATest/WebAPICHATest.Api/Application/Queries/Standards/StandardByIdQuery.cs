using WebAPICHATest.Api.Application.Queries.Standards;

namespace WebAPICHATest.Api.Application.Queries.Standards
{
    public class StandardByIdQuery : PaginatedQuery, IRequest<QueryResult<StandardViewModel>>
    {
        public string? StandardId { get; set; }

        public StandardByIdQuery(string? standardId)
        {
            StandardId = standardId;
        }
    }
}
