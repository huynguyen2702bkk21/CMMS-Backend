using WebAPICHATest.Api.Application.Queries.MaintenanceRequests;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;

namespace WebAPICHATest.Api.Application.Queries.Equipments
{
    public class EquipmentByIdQuery : PaginatedQuery, IRequest<QueryResult<EquipmentViewModel>>
    {
        public string EquipmentId { get; set; }

        public EquipmentByIdQuery(string? equipmentId)
        {
            EquipmentId = equipmentId;
        }
    }
}
