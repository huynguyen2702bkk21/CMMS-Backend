using WebAPICHATest.Api.Application.Queries.Sounds;
using WebAPICHATest.Domain.AggregateModels.SoundAggregate;
using WebAPICHATest.Infrastructure;

namespace WebAPICHATest.Api.Application.Queries.Sounds
{
    public class SoundsQueryHandler : IRequestHandler<SoundsQuery, List<SoundViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SoundsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SoundViewModel>> Handle(SoundsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Sounds.AsNoTracking().ToListAsync();

            return _mapper.Map<List<Sound>, List<SoundViewModel>>(result);
        }
    }
}
