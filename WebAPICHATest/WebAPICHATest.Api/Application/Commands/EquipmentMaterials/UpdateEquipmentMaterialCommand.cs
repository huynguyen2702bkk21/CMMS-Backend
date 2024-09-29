using static WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate.EquipmentMaterial;
using System.Runtime.Serialization;

namespace WebAPICHATest.Api.Application.Commands.EquipmentMaterials
{
    [DataContract]
    public class UpdateEquipmentMaterialCommand : IRequest<bool>
    {
        public string? EquipmentMaterialId { get; set; }
        public string? MaterialInfor { get; set; }
        public decimal? FullTime { get; set; }
        public decimal? UsedTime { get; set; }
        public DateTime InstalledTime { get; set; }

        public UpdateEquipmentMaterialCommand(string? equipmentMaterialId, string? materialInfor, decimal? fullTime, decimal? usedTime, DateTime installedTime)
        {
            EquipmentMaterialId = equipmentMaterialId;
            MaterialInfor = materialInfor;
            FullTime = fullTime;
            UsedTime = usedTime;
            InstalledTime = installedTime;
        }
    }
}
