using static WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;
using System.Runtime.Serialization;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;

namespace WebAPICHATest.Api.Application.Commands.Equipments
{
    [DataContract]
    public class UpdateEquipmentCommand : IRequest<bool>
    {
        public string? EquipmentId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public List<string>? Materials { get; set; }

        public UpdateEquipmentCommand(string? equipmentId, string? code, string? name, string? type, List<string>? materials)
        {
            EquipmentId = equipmentId;
            Code = code;
            Name = name;
            Type = type;
            Materials = materials;
        }
    }

}
