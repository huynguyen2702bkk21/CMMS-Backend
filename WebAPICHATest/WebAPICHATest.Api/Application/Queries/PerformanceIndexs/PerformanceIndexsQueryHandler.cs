using WebAPICHATest.Api.Application.Queries.PerformanceIndexs;
using WebAPICHATest.Domain.AggregateModels.PerformanceIndexAggregate;
using WebAPICHATest.Infrastructure;

namespace WebAPICHATest.Api.Application.Queries.PerformanceIndexs
{
    public class PerformanceIndexsQueryHandler : IRequestHandler<PerformanceIndexsQuery, List<PerformanceIndexViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PerformanceIndexsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PerformanceIndexViewModel>> Handle(PerformanceIndexsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.PerformanceIndexs
                .Include(x => x.History)
                .AsNoTracking().ToListAsync();

            return _mapper.Map<List<PerformanceIndex>, List<PerformanceIndexViewModel>>(result);
        }
    }
}
