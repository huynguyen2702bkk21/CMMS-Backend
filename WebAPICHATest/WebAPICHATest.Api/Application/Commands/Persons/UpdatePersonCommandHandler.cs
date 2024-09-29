using WebAPICHATest.Api.Application.Commands.Persons;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
using WebAPICHATest.Domain.AggregateModels.WorkingTimeAggregate;

namespace WebAPICHATest.Api.Application.Commands.Persons
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, bool>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IWorkingTimeRepository _workingTimeRepository;

        public UpdatePersonCommandHandler(IPersonRepository personRepository, IWorkingTimeRepository workingTimeRepository)
        {
            _personRepository = personRepository;
            _workingTimeRepository = workingTimeRepository;
        }

        public async Task<bool> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetById(request.PersonId) ?? throw new NotFoundException();
            person.Update(personName: request.PersonName, 
                          scheduleWorkingTimes: null);
            _personRepository.Update(person);


            return await _personRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
