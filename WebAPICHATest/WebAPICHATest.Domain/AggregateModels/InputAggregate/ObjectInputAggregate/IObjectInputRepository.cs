using WebAPICHATest.Domain.AggregateModels.InputAggregate.Common;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;

namespace WebAPICHATest.Domain.AggregateModels.InputAggregate.ObjectInputAggregate
{
    public interface IObjectInputRepository
    {
        Task<ListJobInforReturn> Implement(ObjectPostInput input);
        Task<string> UpdateListMaintenanceReponseReturn(ListMaintenanceResponseReturn maintenanceResponses, CancellationToken cancellationToken);
        Task<ListMaintenanceResponseReturn>? GetListMaintenanceResponseReturn();
    }
}
