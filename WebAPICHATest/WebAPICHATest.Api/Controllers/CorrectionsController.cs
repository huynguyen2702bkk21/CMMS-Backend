using WebAPICHATest.Api.Application.Commands.Corrections;
using WebAPICHATest.Api.Application.Queries.Corrections;
using WebAPICHATest.Api.Application.Queries;

namespace WebAPICHATest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorrectionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CorrectionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCorrection([FromBody] CreateCorrectionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCorrection(string id, [FromBody] UpdateCorrectionViewModel request)
        {
            var command = new UpdateCorrectionCommand(id, request.CorrectionCode, request.CorrectionName, request.CorrectionType, request.EstProcessTime, request.Note);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<QueryResult<CorrectionViewModel>> GetCorrectionById(string id)
        {
            var command = new CorrectionByIdQuery(id);
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<List<CorrectionViewModel>> GetCorrections()
        {
            var command = new CorrectionsQuery();
            return await _mediator.Send(command);
        }
    }
}
