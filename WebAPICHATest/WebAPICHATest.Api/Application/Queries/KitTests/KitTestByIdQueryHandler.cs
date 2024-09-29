using WebAPICHATest.Api.Application.Queries.KitTests;
using WebAPICHATest.Domain.AggregateModels.KitTestAggregate;
using WebAPICHATest.Infrastructure;

namespace WebAPICHATest.Api.Application.Queries.KitTests
{
    public class KitTestByIdQueryHandler : IRequestHandler<KitTestByIdQuery, QueryResult<KitTestViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public KitTestByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<KitTestViewModel>> Handle(KitTestByIdQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.KitTests
                .AsNoTracking();

            if (request.KitTestId is not null)
            {
                queryable = queryable.Where(x => x.KitTestId == request.KitTestId);
            }

            int totalItems = await queryable.CountAsync();

            queryable = queryable
                .OrderBy(x => x.KitTestId)
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize);

            var requests = await queryable.ToListAsync();
            var queryResult = new QueryResult<KitTest>(requests, totalItems);

            return _mapper.Map<QueryResult<KitTest>, QueryResult<KitTestViewModel>>(queryResult);
        }
    }
}
