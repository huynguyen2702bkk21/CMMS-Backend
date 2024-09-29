using WebAPICHATest.Api.Application.Commands.MaintenanceResponses;
using WebAPICHATest.Api.Application.Queries.MaintenanceResponses;
using WebAPICHATest.Api.Application.Queries;
using WebAPICHATest.Domain.AggregateModels.EquipmentAggregate;
using WebAPICHATest.Domain.AggregateModels.MoldAggregate;
using WebAPICHATest.Infrastructure;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Api.Application.Queries.MaintenanceRequests;
using WebAPICHATest.Domain.AggregateModels.NotificationAggregate;
using OneSignalApi.Api;
using OneSignalApi.Client;
using OneSignalApi.Model;

namespace WebAPICHATest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceResponsesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MaintenanceResponsesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaintenanceResponse([FromBody] CreateMaintenanceResponseCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaintenanceResponse(string id, [FromBody] UpdateMaintenanceResponseViewModel request)
        {


            var command = new UpdateMaintenanceResponseCommand(maintenanceResponseId: id, 
                                                               cause: request.Cause, 
                                                               correction: request.Correction,
                                                               plannedStart: request.PlannedStart, 
                                                               plannedFinish: request.PlannedFinish, 
                                                               estProcessTime: request.EstProcessTime,
                                                               actualStartTime: request.ActualStartTime, 
                                                               actualFinishTime: request.ActualFinishTime,
                                                               status: request.Status, 
                                                               responsiblePerson: request.ResponsiblePerson, 
                                                               priority: request.Priority, 
                                                               problem: request.Problem, 
                                                               images: request.Images,
                                                               sounds: request.Sounds,
                                                               materials: request.Materials, 
                                                               code: request.Code, request.Note, 
                                                               request: request.Request, 
                                                               maintenanceObject: request.MaintenanceObject, 
                                                               equipment: request.Equipment, 
                                                               mold: request.Mold, 
                                                               dueDate: request.DueDate, 
                                                               type: request.Type,
                                                               inspectionReports: request.InspectionReports);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<QueryResult<MaintenanceResponseViewModel>> GetMaintenanceResponseById(string id)
        {
            var command = new MaintenanceResponseByIdQuery(id);
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<List<MaintenanceResponseViewModel>> GetMaintenanceResponses([FromQuery] MaintenanceResponsesQuery query)
        {
            return await _mediator.Send(query);
        }


    }
}
