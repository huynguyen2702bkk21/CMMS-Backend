//using WebAPICHATest.Api.Application.Commands.ChartObjs;
//using WebAPICHATest.Api.Application.Queries;
//using WebAPICHATest.Api.Application.Queries.ChartObjs;

//namespace WebAPICHATest.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ChartObjsController : ControllerBase
//    {
//        private readonly IMediator _mediator;

//        public ChartObjsController(IMediator mediator)
//        {
//            _mediator = mediator;
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateChartObj([FromBody] CreateChartObjCommand command)
//        {
//            var result = await _mediator.Send(command);
//            return Ok(result);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateChartObj(string id, [FromBody] UpdateChartObjViewModel chartObj)
//        {
//            var command = new UpdateChartObjCommand(id, chartObj.Name, chartObj.Value);
//            var result = await _mediator.Send(command);
//            return Ok(result);
//        }

//        [HttpGet("{id}")]
//        public async Task<QueryResult<ChartObjViewModel>> GetChartObjById(string id)
//        {
//            var command = new ChartObjByIdQuery(id);
//            return await _mediator.Send(command);
//        }

//        [HttpGet]
//        public async Task<List<ChartObjViewModel>> GetChartObjs()
//        {
//            var command = new ChartObjsQuery();
//            return await _mediator.Send(command);
//        }
//    }
//}
