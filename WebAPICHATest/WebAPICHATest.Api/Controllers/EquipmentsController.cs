//using WebAPICHATest.Api.Application.Queries.Equipments;
using WebAPICHATest.Api.Application.Commands.Equipments;
using WebAPICHATest.Domain.AggregateModels.EquipmentAggregate;
using WebAPICHATest.Api.Application.Exceptions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using WebAPICHATest.Api.Application.Commands.MaintenanceRequests;
using WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate;
using WebAPICHATest.Api.Application.Queries.MaintenanceRequests;
using WebAPICHATest.Api.Application.Queries;
using WebAPICHATest.Api.Application.Queries.Equipments;

namespace WebAPICHATest.Api.Equipments
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EquipmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEquipment([FromBody] CreateEquipmentCommand command)
        {
            Console.WriteLine("Through");
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEquipment(string id, [FromBody] UpdateEquipmentViewModel request)
        {
            var command = new UpdateEquipmentCommand(id, request.Code, request.Name, request.Type, request.Materials);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<QueryResult<EquipmentViewModel>> GetEquipmentById(string id)
        {
            var command = new EquipmentByIdQuery(id);
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<List<EquipmentViewModel>> GetEquipments()
        {
            var command = new EquipmentsQuery();
            return await _mediator.Send(command);
        }
    }
}
