using WebAPICHATest.Api.Application.Commands.Materials;
using WebAPICHATest.Api.Application.Queries.Materials;
using WebAPICHATest.Api.Application.Queries;

namespace WebAPICHATest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MaterialsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaterial([FromBody] CreateMaterialCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaterial(string id, [FromBody] UpdateMaterialViewModel request)
        {
            var command = new UpdateMaterialCommand(id, request.MaterialInfor, request.Status);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<QueryResult<MaterialViewModel>> GetMaterialById(string id)
        {
            var command = new MaterialByIdQuery(id);
            return await _mediator.Send(command);
        }

        [HttpGet("Sku/{sku}")]
        public async Task<QueryResult<MaterialViewModel>> GetMaterialBySku(string sku)
        {
            var command = new MaterialBySkuQuery(sku);
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<List<MaterialViewModel>> GetMaterials()
        {
            var command = new MaterialsQuery();
            return await _mediator.Send(command);
        }
    }
}
