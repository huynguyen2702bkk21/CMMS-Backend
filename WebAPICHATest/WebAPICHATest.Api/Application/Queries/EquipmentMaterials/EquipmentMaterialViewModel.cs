using static WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate.EquipmentMaterial;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;

namespace WebAPICHATest.Api.Application.Queries.EquipmentMaterials
{
    public class EquipmentMaterialViewModel
    {
        public string EquipmentMaterialId { get; set; }
        public MaterialInfor MaterialInfor { get; set; }
        public decimal FullTime { get; set; }
        public decimal UsedTime { get; set; }
        public DateTime InstalledTime { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private EquipmentMaterialViewModel() { }

        public EquipmentMaterialViewModel(string equipmentMaterialId, MaterialInfor materialInfor, decimal fullTime, decimal usedTime, DateTime installedTime)
        {
            EquipmentMaterialId = equipmentMaterialId;
            MaterialInfor = materialInfor;
            FullTime = fullTime;
            UsedTime = usedTime;
            InstalledTime = installedTime;
        }


#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
