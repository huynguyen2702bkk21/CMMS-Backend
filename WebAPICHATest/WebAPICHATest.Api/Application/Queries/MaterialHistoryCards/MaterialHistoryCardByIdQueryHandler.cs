using WebAPICHATest.Api.Application.Queries.MaterialHistoryCards;
using WebAPICHATest.Domain.AggregateModels.MaterialHistoryCardAggregate;
using WebAPICHATest.Infrastructure;

namespace WebAPICHATest.Api.Application.Queries.MaterialHistoryCards
{
    public class MaterialHistoryCardByIdQueryHandler : IRequestHandler<MaterialHistoryCardByIdQuery, QueryResult<MaterialHistoryCardViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MaterialHistoryCardByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<MaterialHistoryCardViewModel>> Handle(MaterialHistoryCardByIdQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.MaterialHistoryCards
                .AsNoTracking();

            if (request.MaterialHistoryCardId is not null)
            {
                queryable = queryable.Where(x => x.MaterialHistoryCardId == request.MaterialHistoryCardId);
            }

            int totalItems = await queryable.CountAsync();

            queryable = queryable
                .OrderBy(x => x.MaterialHistoryCardId)
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize);

            var requests = await queryable.ToListAsync();
            var queryResult = new QueryResult<MaterialHistoryCard>(requests, totalItems);

            return _mapper.Map<QueryResult<MaterialHistoryCard>, QueryResult<MaterialHistoryCardViewModel>>(queryResult);
        }
    }
}
