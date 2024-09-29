using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Infrastructure;

namespace WebAPICHATest.Api.Application.Queries.Materials
{
    public class MaterialBySkuQueryHandler : IRequestHandler<MaterialBySkuQuery, QueryResult<MaterialViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MaterialBySkuQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<MaterialViewModel>> Handle(MaterialBySkuQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.Materials
                .Include(x => x.MaterialInfor)
                .AsNoTracking();

            if (request.Sku is not null)
            {
                queryable = queryable.Where(x => x.Sku == request.Sku);
            }

            int totalItems = await queryable.CountAsync();

            queryable = queryable
                .OrderBy(x => x.Sku)
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize);

            var requests = await queryable.ToListAsync();
            var queryResult = new QueryResult<Material>(requests, totalItems);

            return _mapper.Map<QueryResult<Material>, QueryResult<MaterialViewModel>>(queryResult);
        }
    }
}
