using WebAPICHATest.Api.Application.Commands.WorkingTimes;
using WebAPICHATest.Api.Application.Queries.WorkingTimes;
using WebAPICHATest.Api.Application.Queries;

namespace WebAPICHATest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingTimesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkingTimesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkingTime([FromBody] CreateWorkingTimeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorkingTime(string id, [FromBody] UpdateWorkingTimeViewModel request)
        {
            var command = new UpdateWorkingTimeCommand(id, request.From, request.To);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<QueryResult<WorkingTimeViewModel>> GetWorkingTimeById(string id)
        {
            var command = new WorkingTimeByIdQuery(id);
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<List<WorkingTimeViewModel>> GetWorkingTimes()
        {
            var command = new WorkingTimesQuery();
            return await _mediator.Send(command);
        }
    }
}
