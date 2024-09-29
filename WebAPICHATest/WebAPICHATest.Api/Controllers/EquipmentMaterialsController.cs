using WebAPICHATest.Api.Application.Commands.EquipmentMaterials;
using WebAPICHATest.Api.Application.Queries.EquipmentMaterials;
using WebAPICHATest.Api.Application.Queries;
using WebAPICHATest.Api.Application.Queries.EquipmentEquipmentMaterials;

namespace WebAPICHATest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentMaterialsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EquipmentMaterialsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEquipmentMaterial([FromBody] CreateEquipmentMaterialCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEquipmentMaterial(string id, [FromBody] UpdateEquipmentMaterialViewModel request)
        {
            var command = new UpdateEquipmentMaterialCommand(id, request.MaterialInfor, request.FullTime, request.UsedTime, request.InstalledTime);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<QueryResult<EquipmentMaterialViewModel>> GetEquipmentMaterialById(string id)
        {
            var command = new EquipmentMaterialByIdQuery(id);
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<List<EquipmentMaterialViewModel>> GetEquipmentMaterials()
        {
            var command = new EquipmentMaterialsQuery();
            return await _mediator.Send(command);
        }
    }
}
