using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Api.Application.Queries.Materials;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;
using WebAPICHATest.Infrastructure;

namespace WebAPICHATest.Api.Application.Queries.MaterialInfors
{
    public class MaterialInforByIdQueryHandler : IRequestHandler<MaterialInforByIdQuery, QueryResult<MaterialInforViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMaterialInforRepository _materialInforRepository;
        private readonly IMaterialRepository _materialRepository;

        public MaterialInforByIdQueryHandler(ApplicationDbContext context, IMapper mapper,
                                             IMaterialInforRepository materialInforRepository,
                                             IMaterialRepository materialRepository)
        { 
            _context = context;
            _mapper = mapper;
            _materialRepository = materialRepository;
            _materialInforRepository = materialInforRepository;
        }

        public async Task<QueryResult<MaterialInforViewModel>> Handle(MaterialInforByIdQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.MaterialInfors
                .Include(x => x.MaterialHistoryCards)
                .AsNoTracking();

            if (request.MaterialInforId is not null)
            {
                queryable = queryable.Where(x => x.MaterialInforId == request.MaterialInforId);
            }

            int totalItems = await queryable.CountAsync();

            queryable = queryable
                .OrderBy(x => x.MaterialInforId)
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize);

            var requests = await queryable.ToListAsync();

            List<MaterialInforGetViewModel> materialInforGetViewModels = new List<MaterialInforGetViewModel>();
            foreach (MaterialInfor materialInfor in requests)
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


            var queryResult = new QueryResult<MaterialInforGetViewModel>(materialInforGetViewModels, totalItems);

            return _mapper.Map<QueryResult<MaterialInforGetViewModel>, QueryResult<MaterialInforViewModel>>(queryResult);
        }
    }
}
