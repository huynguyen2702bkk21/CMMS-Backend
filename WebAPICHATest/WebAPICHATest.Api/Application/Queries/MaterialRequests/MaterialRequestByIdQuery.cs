using WebAPICHATest.Api.Application.Queries.MaterialRequests;

namespace WebAPICHATest.Api.Application.Queries.MaterialRequests
{
    public class MaterialRequestByIdQuery : PaginatedQuery, IRequest<QueryResult<MaterialRequestViewModel>>
    {
        public string? MaterialRequestId { get; set; }

        public MaterialRequestByIdQuery(string? equipmentId)
        {
            MaterialRequestId = equipmentId;
        }
    }
}
