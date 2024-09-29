using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialRequestAggregate;
using WebAPICHATest.Domain.AggregateModels.WarehouseMaterialAggregate;
using WebAPICHATest.Infrastructure;

namespace WebAPICHATest.Api.Application.Queries.WarehouseMaterials
{
    public class WarehouseMaterialsQueryHandler : IRequestHandler<WarehouseMaterialsQuery, List<WarehouseMaterial>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMaterialInforRepository _materialInforRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IMaterialRequestRepository _materialRequestRepository;

        private readonly IMapper _mapper;

        public WarehouseMaterialsQueryHandler(ApplicationDbContext context, IMaterialInforRepository materialInforRepository, IMaterialRepository materialRepository, IMaterialRequestRepository materialRequestRepository, IMapper mapper)
        {
            _context = context;
            _materialInforRepository = materialInforRepository;
            _materialRepository = materialRepository;
            _materialRequestRepository = materialRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<WarehouseMaterial>> Handle(WarehouseMaterialsQuery request, CancellationToken cancellationToken)
        {
            var _dbMaterialInfors = await _context.MaterialInfors.AsNoTracking().ToListAsync();
            var _dbMaterials = await _context.Materials.Include(x => x.MaterialInfor).AsNoTracking().ToListAsync();
            var _dbMaterialRequests = await _context.MaterialRequests.AsNoTracking().ToListAsync();

            var result = new List<WarehouseMaterial>();
            foreach (var dbMaterialInfor in _dbMaterialInfors)
            {
                var newWarehouseMaterial = new WarehouseMaterial();
                newWarehouseMaterial.MaterialInfor = dbMaterialInfor;
                var materials = _dbMaterials.Where(x => x.MaterialInfor.MaterialInforId == dbMaterialInfor.MaterialInforId)
                                            .Where(x => x.Status == Material.MaterialStatus.available)
                                            .ToList();

                var currentQuantity = materials?.Count ?? 0;
                newWarehouseMaterial.CurrentQuantity = currentQuantity;
                newWarehouseMaterial.IsEnough = (decimal)currentQuantity >= dbMaterialInfor.MinimumQuantity;
                var materialRequests = _dbMaterialRequests.Where(x => x.MaterialInfor?.MaterialInforId == dbMaterialInfor.MaterialInforId)
                                                          .ToList();

                var lastMaterialRequest = materialRequests?.LastOrDefault();
                if (lastMaterialRequest == null)
                {
                    newWarehouseMaterial.RequestingQuantity = null;
                }
                else
                {
                    if (lastMaterialRequest.ExpectedNumber != null)
                    {
                        newWarehouseMaterial.RequestingQuantity = lastMaterialRequest.ExpectedNumber;
                    }
                    else
                    {
                        newWarehouseMaterial.RequestingQuantity = 0;
                    }
                }
                newWarehouseMaterial.Requests = materialRequests;
                result.Add(newWarehouseMaterial);
            }

            return result;
        }
    }
}
