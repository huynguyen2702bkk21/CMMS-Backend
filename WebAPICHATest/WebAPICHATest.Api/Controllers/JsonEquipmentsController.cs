using WebAPICHATest.Api.Application.Commands.JsonEquipments;
using WebAPICHATest.Api.Application.Queries;

namespace WebAPICHATest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonEquipmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JsonEquipmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJsonEquipment([FromBody] UpdateJsonEquipmentViewModel request)
        {
            var command = new UpdateJsonEquipmentCommand(request.JsonEquipmentString);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
