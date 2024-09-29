using WebAPICHATest.Api.Application.Commands.MaintenanceRequests;
using WebAPICHATest.Api.Application.Queries;
using WebAPICHATest.Api.Application.Queries.MaintenanceRequests;
using WebAPICHATest.Domain.AggregateModels.EquipmentAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebAPICHATest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MaintenanceRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaintenanceRequest([FromBody] CreateMaintenanceRequestCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaintenanceRequest(string id, [FromBody] UpdateMaintenanceRequestViewModel request)
        {
            var command = new UpdateMaintenanceRequestCommand(id, request.Code, request.Problem, 
                            request.RequestedCompletionDate, request.RequestedPriority, request.Requester,
                            request.Status, request.Reviewer, request.SubmissionDate, request.Type, request.MaintenanceObject,
                            request.Equipment, request.Mold, request.Images, request.Sounds, request.ResponsiblePerson, 
                            request.EstProcessingTime, request.PlannedStart);
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<QueryResult<MaintenanceRequestViewModel>> GetMaintenanceRequestById(string id)
        {
            var command = new MaintenanceRequestByIdQuery(id);
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<List<MaintenanceRequestViewModel>> GetMaintenanceRequests([FromQuery] MaintenanceRequestsQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
