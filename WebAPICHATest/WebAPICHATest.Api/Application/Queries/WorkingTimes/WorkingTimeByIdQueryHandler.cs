using WebAPICHATest.Api.Application.Queries.WorkingTimes;
using WebAPICHATest.Domain.AggregateModels.WorkingTimeAggregate;
using WebAPICHATest.Infrastructure;

namespace WebAPICHATest.Api.Application.Queries.WorkingTimes
{
    public class WorkingTimeByIdQueryHandler : IRequestHandler<WorkingTimeByIdQuery, QueryResult<WorkingTimeViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public WorkingTimeByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<WorkingTimeViewModel>> Handle(WorkingTimeByIdQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.WorkingTimes
                .AsNoTracking();

            if (request.WorkingTimeId is not null)
            {
                queryable = queryable.Where(x => x.WorkingTimeId == request.WorkingTimeId);
            }

            int totalItems = await queryable.CountAsync();

            queryable = queryable
                .OrderBy(x => x.WorkingTimeId)
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize);

            var requests = await queryable.ToListAsync();
            var queryResult = new QueryResult<WorkingTime>(requests, totalItems);

            return _mapper.Map<QueryResult<WorkingTime>, QueryResult<WorkingTimeViewModel>>(queryResult);
        }
    }
}
