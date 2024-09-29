using System.Runtime.Serialization;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;
using WebAPICHATest.Domain.AggregateModels.ChartObjAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.PerformanceIndexAggregate;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.WorkingTimeAggregate;

namespace WebAPICHATest.Api.Application.Commands.Equipments
{
    [DataContract]
    public class CreateEquipmentCommand : IRequest<bool>
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }

        public CreateEquipmentCommand(string? code, string? name, string? type)
        {
            Code = code;
            Name = name;
            Type = type;
        }
    }

}
