using WebAPICHATest.Api.Application.Commands.Standards;
using WebAPICHATest.Api.Application.Queries.Standards;
using WebAPICHATest.Api.Application.Queries;

namespace WebAPICHATest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandardsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StandardsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStandard([FromBody] CreateStandardCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStandard(string id, [FromBody] UpdateStandardViewModel request)
        {
            var command = new UpdateStandardCommand(standardId: id, 
                                                    images: request.Images, 
                                                    measurements: request.Measurements,
                                                    kitTest: request.KitTest);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<QueryResult<StandardViewModel>> GetStandardById(string id)
        {
            var command = new StandardByIdQuery(id);
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<List<StandardViewModel>> GetStandards()
        {
            var command = new StandardsQuery();
            return await _mediator.Send(command);
        }
    }
}
