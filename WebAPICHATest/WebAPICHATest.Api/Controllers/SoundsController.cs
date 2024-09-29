using WebAPICHATest.Api.Application.Commands.Sounds;
using WebAPICHATest.Api.Application.Queries.Sounds;
using WebAPICHATest.Api.Application.Queries;

namespace WebAPICHATest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoundsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SoundsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSound([FromBody] CreateSoundCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSound(string id, [FromBody] UpdateSoundViewModel request)
        {
            var command = new UpdateSoundCommand(id, request.Value);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<QueryResult<SoundViewModel>> GetSoundById(string id)
        {
            var command = new SoundByIdQuery(id);
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<List<SoundViewModel>> GetSounds()
        {
            var command = new SoundsQuery();
            return await _mediator.Send(command);
        }
    }
}
