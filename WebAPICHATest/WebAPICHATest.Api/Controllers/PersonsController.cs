using WebAPICHATest.Api.Application.Commands.Persons;
using WebAPICHATest.Api.Application.Queries.Persons;
using WebAPICHATest.Api.Application.Queries;

namespace WebAPICHATest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePersonCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(string id, [FromBody] UpdatePersonViewModel request)
        {
            var command = new UpdatePersonCommand(id, request.PersonName, request.ScheduleWorkingTimes);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<QueryResult<PersonViewModel>> GetPersonById(string id)
        {
            var command = new PersonByIdQuery(id);
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<List<PersonViewModel>> GetPersons()
        {
            var command = new PersonsQuery();
            return await _mediator.Send(command);
        }
    }
}
