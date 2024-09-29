using WebAPICHATest.Api.Application.Queries.Materials;

namespace WebAPICHATest.Api.Application.Queries.Materials
{
    public class MaterialByIdQuery : PaginatedQuery, IRequest<QueryResult<MaterialViewModel>>
    {
        public string? MaterialId { get; set; }

        public MaterialByIdQuery(string? equipmentId)
        {
            MaterialId = equipmentId;
        }
    }
}
