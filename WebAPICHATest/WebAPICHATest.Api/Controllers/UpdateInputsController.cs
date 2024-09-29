using WebAPICHATest.Api.Application.Commands.Molds;
using WebAPICHATest.Api.Application.Commands.UpdateInputs;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;

namespace WebAPICHATest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateInputsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UpdateInputsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<string> Post([FromBody] AddUpdateInputCommand command)
        {
            return await _mediator.Send(new AddUpdateInputCommand(command.Confirm));
        }
    }
}
