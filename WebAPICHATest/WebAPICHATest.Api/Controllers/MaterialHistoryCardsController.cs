using WebAPICHATest.Api.Application.Commands.MaterialHistoryCards;
using WebAPICHATest.Api.Application.Queries.MaterialHistoryCards;
using WebAPICHATest.Api.Application.Queries;

namespace WebAPICHATest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialHistoryCardsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MaterialHistoryCardsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaterialHistoryCard([FromBody] CreateMaterialHistoryCardCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaterialHistoryCard(string id, [FromBody] UpdateMaterialHistoryCardViewModel request)
        {
            var command = new UpdateMaterialHistoryCardCommand(materialHistoryCardId: id,
                                                               timeStamp: request.TimeStamp,
                                                               before: request.Before, 
                                                               after: request.After,
                                                               input: request.Input,
                                                               output: request.Output,
                                                               materialInfor: request.MaterialInfor,
                                                               note: request.Note);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<QueryResult<MaterialHistoryCardViewModel>> GetMaterialHistoryCardById(string id)
        {
            var command = new MaterialHistoryCardByIdQuery(id);
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<List<MaterialHistoryCardViewModel>> GetMaterialHistoryCards()
        {
            var command = new MaterialHistoryCardsQuery();
            return await _mediator.Send(command);
        }
    }
}
