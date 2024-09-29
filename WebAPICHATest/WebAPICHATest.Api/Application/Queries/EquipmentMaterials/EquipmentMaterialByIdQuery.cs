using WebAPICHATest.Api.Application.Queries.EquipmentMaterials;

namespace WebAPICHATest.Api.Application.Queries.EquipmentEquipmentMaterials
{
    public class EquipmentMaterialByIdQuery : PaginatedQuery, IRequest<QueryResult<EquipmentMaterialViewModel>>
    {
        public string? EquipmentMaterialId { get; set; }

        public EquipmentMaterialByIdQuery(string? equipmentId)
        {
            EquipmentMaterialId = equipmentId;
        }
    }
}
