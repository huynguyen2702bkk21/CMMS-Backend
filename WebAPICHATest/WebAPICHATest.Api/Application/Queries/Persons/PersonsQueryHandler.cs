using Azure;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Api.Application.Queries.Persons;
using WebAPICHATest.Domain.AggregateModels.EquipmentAggregate;
using WebAPICHATest.Domain.AggregateModels.JsonEquipmentAggregate;
using WebAPICHATest.Domain.AggregateModels.JsonPersonAggregate;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
using WebAPICHATest.Domain.AggregateModels.WorkingTimeAggregate;
//using WebAPICHATest.Domain.AggregateModels.JsonPersonAggregate;
using WebAPICHATest.Infrastructure;

namespace WebAPICHATest.Api.Application.Queries.Persons
{
    public class PersonsQueryHandler : IRequestHandler<PersonsQuery, List<PersonViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWorkingTimeRepository _workingTimeRepository;


        public PersonsQueryHandler(ApplicationDbContext context, IMapper mapper, IWorkingTimeRepository workingTimeRepository)
        {
            _context = context;
            _mapper = mapper;
            _workingTimeRepository = workingTimeRepository;
        }

        public async Task<List<PersonViewModel>> Handle(PersonsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Persons
                .AsNoTracking().ToListAsync();

            var listGetViewModel = new List<PersonGetViewModel>();
            foreach(var person in result)
            {
                var newGetViewModel = new PersonGetViewModel(person.PersonId);
                newGetViewModel.PersonName = person.PersonName;
                Console.WriteLine($"person.ScheduleWorkingTimes: {person.ScheduleWorkingTimes}");
                if (person.ScheduleWorkingTimes != null)
                {
                    List<SchedulePersonWorkingTime>? scheduleWorkingTimes = JsonPersonInput.ConvertStringToObject(person.ScheduleWorkingTimes);
                    newGetViewModel.ScheduleWorkingTimes = scheduleWorkingTimes;
                }
                listGetViewModel.Add(newGetViewModel);
            }

            return _mapper.Map<List<PersonGetViewModel>, List<PersonViewModel>>(listGetViewModel);
        }
    }
}
