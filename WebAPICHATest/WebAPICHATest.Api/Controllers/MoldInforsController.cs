using WebAPICHATest.Api.Application.Commands.MoldInfors;
using WebAPICHATest.Api.Application.Queries.MoldInfors;
using WebAPICHATest.Api.Application.Queries;

namespace WebAPICHATest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoldInforsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoldInforsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMoldInfor([FromBody] CreateMoldInforCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMoldInfor(string id, [FromBody] UpdateMoldInforViewModel request)
        {
            var command = new UpdateMoldInforCommand(id, request.Cavity, request.DocumentLink, request.Images, request.Standard, request.Products);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<QueryResult<MoldInforViewModel>> GetMoldInforById(string id)
        {
            var command = new MoldInforByIdQuery(id);
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<List<MoldInforViewModel>> GetMoldInfors()
        {
            var command = new MoldInforsQuery();
            return await _mediator.Send(command);
        }
    }
}
