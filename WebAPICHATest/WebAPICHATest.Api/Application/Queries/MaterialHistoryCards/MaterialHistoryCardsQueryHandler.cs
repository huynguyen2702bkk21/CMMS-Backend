using WebAPICHATest.Api.Application.Queries.MaterialHistoryCards;
using WebAPICHATest.Domain.AggregateModels.MaterialHistoryCardAggregate;
using WebAPICHATest.Infrastructure;

namespace WebAPICHATest.Api.Application.Queries.MaterialHistoryCards
{
    public class MaterialHistoryCardsQueryHandler : IRequestHandler<MaterialHistoryCardsQuery, List<MaterialHistoryCardViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MaterialHistoryCardsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MaterialHistoryCardViewModel>> Handle(MaterialHistoryCardsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.MaterialHistoryCards
                .AsNoTracking().ToListAsync();

            return _mapper.Map<List<MaterialHistoryCard>, List<MaterialHistoryCardViewModel>>(result);
        }
    }
}
