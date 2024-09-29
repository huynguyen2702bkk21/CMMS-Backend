using WebAPICHATest.Api.Application.Commands.KitTests;
using WebAPICHATest.Api.Application.Queries.KitTests;
using WebAPICHATest.Api.Application.Queries;

namespace WebAPICHATest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitTestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public KitTestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateKitTest([FromBody] CreateKitTestCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKitTest(string id, [FromBody] UpdateKitTestViewModel request)
        {
            var command = new UpdateKitTestCommand(id, request.Code, request.Name);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<QueryResult<KitTestViewModel>> GetKitTestById(string id)
        {
            var command = new KitTestByIdQuery(id);
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<List<KitTestViewModel>> GetKitTests()
        {
            var command = new KitTestsQuery();
            return await _mediator.Send(command);
        }
    }
}
