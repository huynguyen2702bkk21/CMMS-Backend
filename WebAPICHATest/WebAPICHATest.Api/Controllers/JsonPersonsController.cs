using WebAPICHATest.Api.Application.Commands.JsonPersons;
using WebAPICHATest.Api.Application.Commands.NotificationModels;

namespace WebAPICHATest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonPersonsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JsonPersonsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJsonPerson([FromBody] UpdateJsonPersonViewModel request)
        {
            var command = new UpdateJsonPersonCommand(request.JsonPersonString);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
