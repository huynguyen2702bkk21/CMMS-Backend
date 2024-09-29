using WebAPICHATest.Api.Application.Queries.KitTests;

namespace WebAPICHATest.Api.Application.Queries.KitTests
{
    public class KitTestByIdQuery : PaginatedQuery, IRequest<QueryResult<KitTestViewModel>>
    {
        public string KitTestId { get; set; }

        public KitTestByIdQuery(string? equipmentId)
        {
            KitTestId = equipmentId;
        }
    }
}
