using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Api.Application.Queries.Persons;
using WebAPICHATest.Domain.AggregateModels.JsonEquipmentAggregate;
using WebAPICHATest.Domain.AggregateModels.JsonPersonAggregate;
//using WebAPICHATest.Domain.AggregateModels.JsonPersonAggregate;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
using WebAPICHATest.Domain.AggregateModels.WorkingTimeAggregate;
using WebAPICHATest.Infrastructure;

namespace WebAPICHATest.Api.Application.Queries.Persons
{
    public class PersonByIdQueryHandler : IRequestHandler<PersonByIdQuery, QueryResult<PersonViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWorkingTimeRepository _workingTimeRepository;


        public PersonByIdQueryHandler(ApplicationDbContext context, IMapper mapper, IWorkingTimeRepository workingTimeRepository)
        {
            _context = context;
            _mapper = mapper;
            _workingTimeRepository = workingTimeRepository;
        }

        public async Task<QueryResult<PersonViewModel>> Handle(PersonByIdQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.Persons
                .AsNoTracking();

            if (request.PersonId is not null)
            {
                queryable = queryable.Where(x => x.PersonId == request.PersonId);
            }

            int totalItems = await queryable.CountAsync();

            queryable = queryable
                .OrderBy(x => x.PersonId)
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize);

            var requests = await queryable.ToListAsync();

            var listGetViewModel = new List<PersonGetViewModel>();
            foreach (var person in requests)
            {
                var newGetViewModel = new PersonGetViewModel(person.PersonId);
                newGetViewModel.PersonName = person.PersonName;
                if (person.ScheduleWorkingTimes != null)
                {
                    List<SchedulePersonWorkingTime>? scheduleWorkingTimes = JsonPersonInput.ConvertStringToObject(person.ScheduleWorkingTimes);
                    newGetViewModel.ScheduleWorkingTimes = scheduleWorkingTimes;
                }
                listGetViewModel.Add(newGetViewModel);
            }

            var queryResult = new QueryResult<PersonGetViewModel>(listGetViewModel, totalItems);

            return _mapper.Map<QueryResult<PersonGetViewModel>, QueryResult<PersonViewModel>>(queryResult);
        }
    }
}
