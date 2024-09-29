using WebAPICHATest.Api.Application.Commands.Materials;

namespace WebAPICHATest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialListsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MaterialListsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaterialList([FromBody] CreateMaterialListCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
