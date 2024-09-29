using WebAPICHATest.Api.Application.Queries.Sounds;
using WebAPICHATest.Domain.AggregateModels.SoundAggregate;
using WebAPICHATest.Infrastructure;

namespace WebAPICHATest.Api.Application.Queries.Sounds
{
    public class SoundByIdQueryHandler : IRequestHandler<SoundByIdQuery, QueryResult<SoundViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SoundByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<SoundViewModel>> Handle(SoundByIdQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.Sounds
                .AsNoTracking();

            if (request.SoundId is not null)
            {
                queryable = queryable.Where(x => x.SoundId == request.SoundId);
            }

            int totalItems = await queryable.CountAsync();

            queryable = queryable
                .OrderBy(x => x.SoundId)
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize);

            var requests = await queryable.ToListAsync();
            var queryResult = new QueryResult<Sound>(requests, totalItems);

            return _mapper.Map<QueryResult<Sound>, QueryResult<SoundViewModel>>(queryResult);
        }
    }
}
