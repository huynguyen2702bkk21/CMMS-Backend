using WebAPICHATest.Api.Application.Commands.MaterialInfors;
using WebAPICHATest.Api.Application.Queries;
using WebAPICHATest.Api.Application.Queries.MaterialInfors;

namespace WebAPICHATest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialInforsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MaterialInforsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaterialInfor([FromBody] CreateMaterialInforCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaterialInfor(string id, [FromBody] UpdateMaterialInforViewModel request)
        {
            var command = new UpdateMaterialInforCommand(id, request.Code, request.Name, request.Unit, request.MinimumQuantity);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<QueryResult<MaterialInforViewModel>> GetMaterialInforById(string id)
        {
            var command = new MaterialInforByIdQuery(id);
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<List<MaterialInforViewModel>> GetMaterialInfors()
        {
            var command = new MaterialInforsQuery();
            return await _mediator.Send(command);
        }
    }
}
