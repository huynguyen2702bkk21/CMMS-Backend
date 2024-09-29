using WebAPICHATest.Api.Application.Commands.MaterialRequests;
using WebAPICHATest.Api.Application.Queries.MaterialRequests;
using WebAPICHATest.Api.Application.Queries;
using WebAPICHATest.Api.Application.Queries.MaintenanceRequests;

namespace WebAPICHATest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MaterialRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaterialRequest([FromBody] CreateMaterialRequestCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaterialRequest(string id, [FromBody] UpdateMaterialRequestViewModel request)
        {
            var command = new UpdateMaterialRequestCommand(materialRequestId: id, 
                                                           materialInfor: request.MaterialInfor, 
                                                           currentNumber: request.CurrentNumber, 
                                                           additionalNumber: request.AdditionalNumber, 
                                                           expectedNumber: request.ExpectedNumber,
                                                           expectedDate: request.ExpectedDate, 
                                                           status: request.Status);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<QueryResult<MaterialRequestViewModel>> GetMaterialRequestById(string id)
        {
            var command = new MaterialRequestByIdQuery(id);
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<List<MaterialRequestViewModel>> GetMaterialRequests([FromQuery] MaterialRequestsQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
