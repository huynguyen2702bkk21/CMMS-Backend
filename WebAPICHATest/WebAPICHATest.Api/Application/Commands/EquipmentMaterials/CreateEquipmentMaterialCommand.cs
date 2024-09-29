using static WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate.EquipmentMaterial;
using System.Runtime.Serialization;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;

namespace WebAPICHATest.Api.Application.Commands.EquipmentMaterials
{
    [DataContract]
    public class CreateEquipmentMaterialCommand : IRequest<bool>
    {
        public string? MaterialInfor { get; set; }
        public decimal? FullTime { get; set; }
        public DateTime InstalledTime { get; set; }

        public CreateEquipmentMaterialCommand(string? materialInfor, decimal? fullTime, DateTime installedTime)
        {
            MaterialInfor = materialInfor;
            FullTime = fullTime;
            InstalledTime = installedTime;
        }
    }
}
