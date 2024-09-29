using WebAPICHATest.Api.Application.Queries.PerformanceIndexs;
using WebAPICHATest.Domain.AggregateModels.PerformanceIndexAggregate;
using WebAPICHATest.Infrastructure;

namespace WebAPICHATest.Api.Application.Queries.PerformanceIndexs
{
    public class PerformanceIndexByIdQueryHandler : IRequestHandler<PerformanceIndexByIdQuery, QueryResult<PerformanceIndexViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PerformanceIndexByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<PerformanceIndexViewModel>> Handle(PerformanceIndexByIdQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.PerformanceIndexs
                .Include(x => x.History)
                .AsNoTracking();

            if (request.PerformanceIndexId is not null)
            {
                queryable = queryable.Where(x => x.PerformanceIndexId == request.PerformanceIndexId);
            }

            int totalItems = await queryable.CountAsync();

            queryable = queryable
                .OrderBy(x => x.PerformanceIndexId)
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize);

            var requests = await queryable.ToListAsync();
            var queryResult = new QueryResult<PerformanceIndex>(requests, totalItems);

            return _mapper.Map<QueryResult<PerformanceIndex>, QueryResult<PerformanceIndexViewModel>>(queryResult);
        }
    }
}
