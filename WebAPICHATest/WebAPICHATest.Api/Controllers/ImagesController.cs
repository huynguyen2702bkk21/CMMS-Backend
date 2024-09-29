using WebAPICHATest.Api.Application.Commands.Images;
using WebAPICHATest.Api.Application.Queries.Images;
using WebAPICHATest.Api.Application.Queries;

namespace WebAPICHATest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ImagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateImage([FromBody] CreateImageCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateImage(string id, [FromBody] UpdateImageViewModel request)
        {
            var command = new UpdateImageCommand(id, request.Value);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<QueryResult<ImageViewModel>> GetImageById(string id)
        {
            var command = new ImageByIdQuery(id);
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<List<ImageViewModel>> GetImages()
        {
            var command = new ImagesQuery();
            return await _mediator.Send(command);
        }
    }
}
