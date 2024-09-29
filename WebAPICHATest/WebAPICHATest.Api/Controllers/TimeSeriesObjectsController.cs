using WebAPICHATest.Api.Application.Commands.TimeSeriesObjects;
using WebAPICHATest.Api.Application.Queries.TimeSeriesObjects;
using WebAPICHATest.Api.Application.Queries;

namespace WebAPICHATest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSeriesObjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TimeSeriesObjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTimeSeriesObject([FromBody] CreateTimeSeriesObjectCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTimeSeriesObject(string id, [FromBody] UpdateTimeSeriesObjectViewModel request)
        {
            var command = new UpdateTimeSeriesObjectCommand(id, request.Time, request.Value);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<QueryResult<TimeSeriesObjectViewModel>> GetTimeSeriesObjectById(string id)
        {
            var command = new TimeSeriesObjectByIdQuery(id);
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<List<TimeSeriesObjectViewModel>> GetTimeSeriesObjects()
        {
            var command = new TimeSeriesObjectsQuery();
            return await _mediator.Send(command);
        }
    }
}
