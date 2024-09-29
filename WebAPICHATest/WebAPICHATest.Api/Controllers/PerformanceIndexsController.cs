using WebAPICHATest.Api.Application.Commands.PerformanceIndexs;
using WebAPICHATest.Api.Application.Queries.PerformanceIndexs;
using WebAPICHATest.Api.Application.Queries;

namespace WebAPICHATest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceIndexsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PerformanceIndexsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerformanceIndex([FromBody] CreatePerformanceIndexCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerformanceIndex(string id, [FromBody] UpdatePerformanceIndexViewModel request)
        {
            var command = new UpdatePerformanceIndexCommand(id, request.IsTracking, request.RecentValue, request.History, request.MaxLength);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<QueryResult<PerformanceIndexViewModel>> GetPerformanceIndexById(string id)
        {
            var command = new PerformanceIndexByIdQuery(id);
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<List<PerformanceIndexViewModel>> GetPerformanceIndexs()
        {
            var command = new PerformanceIndexsQuery();
            return await _mediator.Send(command);
        }
    }
}
