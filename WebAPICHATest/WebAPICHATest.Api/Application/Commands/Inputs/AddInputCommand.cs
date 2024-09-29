using WebAPICHATest.Domain.AggregateModels.InputAggregate.Common;
using WebAPICHATest.Domain.AggregateModels.InputAggregate.ObjectInputAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;

namespace WebAPICHATest.Api.Application.Commands.Inputs
{
    public record AddInputCommand(ObjectPostInput input) : IRequest<ListMaintenanceResponseReturn>;
}
