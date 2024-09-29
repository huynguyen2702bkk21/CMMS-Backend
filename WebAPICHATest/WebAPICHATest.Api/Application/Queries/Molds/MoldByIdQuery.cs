using WebAPICHATest.Api.Application.Queries.Molds;

namespace WebAPICHATest.Api.Application.Queries.Molds
{
    public class MoldByIdQuery : PaginatedQuery, IRequest<QueryResult<MoldViewModel>>
    {
        public string MoldId { get; set; }

        public MoldByIdQuery(string? equipmentId)
        {
            MoldId = equipmentId;
        }
    }
}
