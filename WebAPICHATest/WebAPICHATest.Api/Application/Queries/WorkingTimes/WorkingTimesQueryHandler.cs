using WebAPICHATest.Api.Application.Queries.WorkingTimes;
using WebAPICHATest.Domain.AggregateModels.WorkingTimeAggregate;
using WebAPICHATest.Infrastructure;

namespace WebAPICHATest.Api.Application.Queries.WorkingTimes
{
    public class WorkingTimesQueryHandler : IRequestHandler<WorkingTimesQuery, List<WorkingTimeViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public WorkingTimesQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<WorkingTimeViewModel>> Handle(WorkingTimesQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.WorkingTimes.AsNoTracking().ToListAsync();

            return _mapper.Map<List<WorkingTime>, List<WorkingTimeViewModel>>(result);
        }
    }
}
