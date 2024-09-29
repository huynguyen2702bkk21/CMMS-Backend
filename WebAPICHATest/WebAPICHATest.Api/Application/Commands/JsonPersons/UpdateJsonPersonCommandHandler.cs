using System.Text.Json;
using WebAPICHATest.Api.Application.Commands.JsonPersons;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.JsonPersonAggregate;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;

namespace WebAPICHATest.Api.Application.Commands.JsonPersons
{
    public class UpdateJsonPersonCommandHandler : IRequestHandler<UpdateJsonPersonCommand, bool>
    {
        private readonly IJsonPersonRepository _jsonPersonRepository;
        private readonly IPersonRepository _personRepository;

        public UpdateJsonPersonCommandHandler(IJsonPersonRepository jsonPersonRepository, IPersonRepository personRepository)
        {
            _jsonPersonRepository = jsonPersonRepository;
            _personRepository = personRepository;
        }

        public async Task<bool> Handle(UpdateJsonPersonCommand request, CancellationToken cancellationToken)
        {
            _jsonPersonRepository.Update(request.JsonPersonString);

            var JsonPersonString = request.JsonPersonString;
            var JsonInputArray = JsonPersonString.Root.Deserialize<JsonPersonInput[]>();

            foreach (var jsonInput in JsonInputArray)
            {
                var person = await _personRepository.GetById(jsonInput.id) ?? throw new NotFoundException();
                var ScheduleWorkingTimeString = JsonPersonInput.FromObjectToString(jsonInput.workingTime);
                

                person.ScheduleWorkingTimes = ScheduleWorkingTimeString;
                //Console.WriteLine($"ScheduleWorkingTimes of {person.PersonId}: {person.ScheduleWorkingTimes}");
            }


            return await _jsonPersonRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
