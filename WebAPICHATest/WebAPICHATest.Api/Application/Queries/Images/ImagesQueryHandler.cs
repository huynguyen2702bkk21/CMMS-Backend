using WebAPICHATest.Api.Application.Queries.Images;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Infrastructure;

namespace WebAPICHATest.Api.Application.Queries.Images
{
    public class ImagesQueryHandler : IRequestHandler<ImagesQuery, List<ImageViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ImagesQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ImageViewModel>> Handle(ImagesQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Images.AsNoTracking().ToListAsync();

            return _mapper.Map<List<Image>, List<ImageViewModel>>(result);
        }
    }
}
