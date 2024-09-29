using WebAPICHATest.Api.Application.Queries.EquipmentEquipmentMaterials;
using WebAPICHATest.Api.Application.Queries.EquipmentMaterials;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;
using WebAPICHATest.Infrastructure;

namespace WebAPICHATest.Api.Application.Queries.EquipmentMaterials
{
    public class EquipmentMaterialsQueryHandler : IRequestHandler<EquipmentMaterialsQuery, List<EquipmentMaterialViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EquipmentMaterialsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<EquipmentMaterialViewModel>> Handle(EquipmentMaterialsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.EquipmentMaterials.AsNoTracking().ToListAsync();

            return _mapper.Map<List<EquipmentMaterial>, List<EquipmentMaterialViewModel>>(result);
        }
    }
}
