using WebAPICHATest.Api.Application.Commands.Molds;
using WebAPICHATest.Api.Application.Queries.Molds;
using WebAPICHATest.Api.Application.Queries;

namespace WebAPICHATest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoldsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoldsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMold([FromBody] CreateMoldCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMold(string id, [FromBody] UpdateMoldViewModel request)
        {
            var command = new UpdateMoldCommand(moldId: id, 
                                                code: request.Code, 
                                                name: request.Name, 
                                                cavity: request.Cavity, 
                                                products: request.Products,
                                                documentLink: request.DocumentLink, 
                                                images: request.Images, 
                                                standards: request.Standards, 
                                                status: request.Status, 
                                                materials: request.Materials);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<QueryResult<MoldViewModel>> GetMoldById(string id)
        {
            var command = new MoldByIdQuery(id);
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<List<MoldViewModel>> GetMolds()
        {
            var command = new MoldsQuery();
            return await _mediator.Send(command);
        }
    }
}
