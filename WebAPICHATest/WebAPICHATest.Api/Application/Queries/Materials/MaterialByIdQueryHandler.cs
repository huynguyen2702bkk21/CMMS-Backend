using WebAPICHATest.Api.Application.Queries.Materials;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Infrastructure;

namespace WebAPICHATest.Api.Application.Queries.Materials
{
    public class MaterialByIdQueryHandler : IRequestHandler<MaterialByIdQuery, QueryResult<MaterialViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MaterialByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<MaterialViewModel>> Handle(MaterialByIdQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.Materials
                .Include(x => x.MaterialInfor)
                .AsNoTracking();

            if (request.MaterialId is not null)
            {
                queryable = queryable.Where(x => x.MaterialId == request.MaterialId);
            }

            int totalItems = await queryable.CountAsync();

            queryable = queryable
                .OrderBy(x => x.MaterialId)
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize);

            var requests = await queryable.ToListAsync();
            var queryResult = new QueryResult<Material>(requests, totalItems);

            return _mapper.Map<QueryResult<Material>, QueryResult<MaterialViewModel>>(queryResult);
        }
    }
}
