using WebAPICHATest.Api.Application.Queries.KitTests;
using WebAPICHATest.Domain.AggregateModels.KitTestAggregate;
using WebAPICHATest.Infrastructure;

namespace WebAPICHATest.Api.Application.Queries.KitTests
{
    public class KitTestsQueryHandler : IRequestHandler<KitTestsQuery, List<KitTestViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public KitTestsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<KitTestViewModel>> Handle(KitTestsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.KitTests.AsNoTracking().ToListAsync();

            return _mapper.Map<List<KitTest>, List<KitTestViewModel>>(result);
        }
    }
}
