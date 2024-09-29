using static WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;
using WebAPICHATest.Api.Application.Queries.MaintenanceRequests;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;

namespace WebAPICHATest.Api.Application.Queries.Equipments
{
    public class EquipmentsQuery : IRequest<List<EquipmentViewModel>>
    {
        public EquipmentsQuery() { }
    }

}
