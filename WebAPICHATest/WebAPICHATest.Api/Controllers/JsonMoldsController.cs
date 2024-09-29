using WebAPICHATest.Api.Application.Commands.JsonMolds;

namespace WebAPICHATest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonMoldsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JsonMoldsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJsonMold([FromBody] UpdateJsonMoldViewModel request)
        {
            var command = new UpdateJsonMoldCommand(request.JsonMoldString);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
