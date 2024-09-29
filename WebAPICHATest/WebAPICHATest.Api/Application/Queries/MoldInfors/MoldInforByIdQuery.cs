using WebAPICHATest.Api.Application.Queries.MoldInfors;

namespace WebAPICHATest.Api.Application.Queries.MoldInfors
{
    public class MoldInforByIdQuery : PaginatedQuery, IRequest<QueryResult<MoldInforViewModel>>
    {
        public string? MoldInforId { get; set; }

        public MoldInforByIdQuery(string? equipmentId)
        {
            MoldInforId = equipmentId;
        }
    }
}
