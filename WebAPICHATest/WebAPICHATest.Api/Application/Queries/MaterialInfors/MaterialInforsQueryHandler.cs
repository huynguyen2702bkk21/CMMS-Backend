using WebAPICHATest.Api.Application.Queries.Materials;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;
using WebAPICHATest.Infrastructure;

namespace WebAPICHATest.Api.Application.Queries.MaterialInfors
{
    public class MaterialInforsQueryHandler : IRequestHandler<MaterialInforsQuery, List<MaterialInforViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMaterialInforRepository _materialInforRepository;
        private readonly IMaterialRepository _materialRepository;

        public MaterialInforsQueryHandler(ApplicationDbContext context, IMapper mapper,
                                          IMaterialInforRepository materialInforRepository,
                                          IMaterialRepository materialRepository)
        {
            _context = context;
            _mapper = mapper;
            _materialRepository = materialRepository;
            _materialInforRepository = materialInforRepository;
        }

        public async Task<List<MaterialInforViewModel>> Handle(MaterialInforsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.MaterialInfors
                .Include(x => x.MaterialHistoryCards)
                .AsNoTracking().ToListAsync();

            List<MaterialInforGetViewModel> materialInforGetViewModels = new List<MaterialInforGetViewModel>();
            foreach(MaterialInfor materialInfor in result)
            {
                MaterialInforGetViewModel newGetViewModel = new MaterialInforGetViewModel(materialInfor.MaterialInforId);
                List<Material>? materials = await _materialRepository.GetListByMaterialInforCode(materialInfor.Code);
                List<MaterialViewModel> materialViewModels = _mapper.Map<List<Material>, List<MaterialViewModel>>(materials);
                //List<string> skus = materials?.Select(x => x.Sku).ToList();

                newGetViewModel.Update(code: materialInfor.Code,
                                       name: materialInfor.Name,
                                       unit: materialInfor.Unit,
                                       minimumQuantity: materialInfor.MinimumQuantity,
                                       materialHistoryCards: materialInfor.MaterialHistoryCards,
                                       materials: materialViewModels);
                materialInforGetViewModels.Add(newGetViewModel);
            }

            return _mapper.Map<List<MaterialInforGetViewModel>, List<MaterialInforViewModel>>(materialInforGetViewModels);
        }
    }
}
