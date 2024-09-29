using WebAPICHATest.Api.Application.Commands.Causes;
using WebAPICHATest.Api.Application.Queries.Causes;
using WebAPICHATest.Api.Application.Queries;

namespace WebAPICHATest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CausesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CausesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCause([FromBody] CreateCauseCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCause(string id, [FromBody] UpdateCauseViewModel request)
        {
            var command = new UpdateCauseCommand(id, request.CauseCode, request.CauseName, request.MaintenanceObject, request.Severity, request.Note);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<QueryResult<CauseViewModel>> GetCauseById(string id)
        {
            var command = new CauseByIdQuery(id);
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<List<CauseViewModel>> GetCauses()
        {
            var command = new CausesQuery();
            return await _mediator.Send(command);
        }
    }
}
