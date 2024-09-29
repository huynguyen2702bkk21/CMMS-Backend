using WebAPICHATest.Api.Application.Queries.EquipmentEquipmentMaterials;
using WebAPICHATest.Api.Application.Queries.EquipmentMaterials;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;
using WebAPICHATest.Infrastructure;

namespace WebAPICHATest.Api.Application.Queries.EquipmentMaterials
{
    public class EquipmentMaterialByIdQueryHandler : IRequestHandler<EquipmentMaterialByIdQuery, QueryResult<EquipmentMaterialViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EquipmentMaterialByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<EquipmentMaterialViewModel>> Handle(EquipmentMaterialByIdQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.EquipmentMaterials
                .AsNoTracking();

            if (request.EquipmentMaterialId is not null)
            {
                queryable = queryable.Where(x => x.EquipmentMaterialId == request.EquipmentMaterialId);
            }

            int totalItems = await queryable.CountAsync();

            queryable = queryable
                .OrderBy(x => x.EquipmentMaterialId)
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize);

            var requests = await queryable.ToListAsync();
            var queryResult = new QueryResult<EquipmentMaterial>(requests, totalItems);

            return _mapper.Map<QueryResult<EquipmentMaterial>, QueryResult<EquipmentMaterialViewModel>>(queryResult);
        }
    }
}
