using WebAPICHATest.Api.Application.Queries.Materials;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Infrastructure;

namespace WebAPICHATest.Api.Application.Queries.Materials
{
    public class MaterialsQueryHandler : IRequestHandler<MaterialsQuery, List<MaterialViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MaterialsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MaterialViewModel>> Handle(MaterialsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Materials
                .Include(x => x.MaterialInfor)
                .AsNoTracking().ToListAsync();

            return _mapper.Map<List<Material>, List<MaterialViewModel>>(result);
        }
    }
}
