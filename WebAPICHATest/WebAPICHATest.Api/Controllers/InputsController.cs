using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPICHATest.Api.Application.Commands.Inputs;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.InputAggregate.ObjectInputAggregate;
using WebAPICHATest.Domain.AggregateModels.InputAggregate.Common;
using WebAPICHATest.Api.Application.Queries.Materials;
using WebAPICHATest.Api.Application.Queries.Inputs;

namespace WebAPICHATest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InputsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ListMaintenanceResponseReturn> Post(ObjectPostInput input)
        {
            return await _mediator.Send(new AddInputCommand(input));
        }

        [HttpGet]
        public async Task<ListMaintenanceResponseReturn> Get()
        {
            var command = new InputsQuery();
            return await _mediator.Send(command);
        }
    }
}
