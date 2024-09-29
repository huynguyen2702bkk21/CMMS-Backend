using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;

namespace WebAPICHATest.Api.Application.Commands.Equipments
{
    public class UpdateEquipmentViewModel
    {
        public string? EquipmentId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public List<string>? Materials { get; set; }

        public UpdateEquipmentViewModel(string? equipmentId, string? code, string? name, string? type, List<string>? materials)
        {
            EquipmentId = equipmentId;
            Code = code;
            Name = name;
            Type = type;
            Materials = materials;
        }

        private UpdateEquipmentViewModel()
        {

        }
    }
}
