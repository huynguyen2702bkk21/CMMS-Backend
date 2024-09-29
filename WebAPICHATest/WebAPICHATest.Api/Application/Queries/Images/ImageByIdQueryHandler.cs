using WebAPICHATest.Api.Application.Queries.Images;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Infrastructure;

namespace WebAPICHATest.Api.Application.Queries.Images
{
    public class ImageByIdQueryHandler : IRequestHandler<ImageByIdQuery, QueryResult<ImageViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ImageByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<ImageViewModel>> Handle(ImageByIdQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.Images
                .AsNoTracking();

            if (request.ImageId is not null)
            {
                queryable = queryable.Where(x => x.ImageId == request.ImageId);
            }

            int totalItems = await queryable.CountAsync();

            queryable = queryable
                .OrderBy(x => x.ImageId)
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize);

            var requests = await queryable.ToListAsync();
            var queryResult = new QueryResult<Image>(requests, totalItems);

            return _mapper.Map<QueryResult<Image>, QueryResult<ImageViewModel>>(queryResult);
        }
    }
}
