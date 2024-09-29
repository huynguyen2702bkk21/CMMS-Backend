using WebAPICHATest.Domain.AggregateModels.WarehouseMaterialAggregate;

namespace WebAPICHATest.Api.Application.Queries.WarehouseMaterials
{
    public class WarehouseMaterialsQuery : IRequest<List<WarehouseMaterial>>
    {
        public WarehouseMaterialsQuery() { }
    }
}
