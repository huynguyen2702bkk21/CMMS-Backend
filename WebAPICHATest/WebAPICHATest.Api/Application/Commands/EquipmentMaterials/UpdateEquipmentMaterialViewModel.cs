using static WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate.EquipmentMaterial;

namespace WebAPICHATest.Api.Application.Commands.EquipmentMaterials
{
    public class UpdateEquipmentMaterialViewModel
    {
        public string? EquipmentMaterialId { get; set; }
        public string? MaterialInfor { get; set; }
        public decimal? FullTime { get; set; }
        public decimal? UsedTime { get; set; }
        public DateTime InstalledTime { get; set; }

        public UpdateEquipmentMaterialViewModel(string? equipmentMaterialId, string? materialInfor, decimal? fullTime, decimal? usedTime, DateTime installedTime)
        {
            EquipmentMaterialId = equipmentMaterialId;
            MaterialInfor = materialInfor;
            FullTime = fullTime;
            UsedTime = usedTime;
            InstalledTime = installedTime;
        }

        private UpdateEquipmentMaterialViewModel()
        {

        }
    }
}
