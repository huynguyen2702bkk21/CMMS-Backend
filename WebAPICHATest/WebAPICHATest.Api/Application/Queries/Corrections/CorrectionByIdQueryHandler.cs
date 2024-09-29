using WebAPICHATest.Api.Application.Queries.Corrections;
using WebAPICHATest.Domain.AggregateModels.CorrectionAggregate;
using WebAPICHATest.Infrastructure;
using static WebAPICHATest.Domain.AggregateModels.CauseAggregate.Cause;

namespace WebAPICHATest.Api.Application.Queries.Corrections
{
    public class CorrectionByIdQueryHandler : IRequestHandler<CorrectionByIdQuery, QueryResult<CorrectionViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CorrectionByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<CorrectionViewModel>> Handle(CorrectionByIdQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.Corrections
                .Include(x => x.MaintenanceResponses)
                .AsNoTracking();

            if (request.CorrectionId is not null)
            {
                queryable = queryable.Where(x => x.CorrectionId == request.CorrectionId);
            }

            int totalItems = await queryable.CountAsync();

            queryable = queryable
                .OrderBy(x => x.CorrectionId)
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize);

            var requests = await queryable.ToListAsync();

            var listGetViewModel = new List<CorrectionGetViewModel>();
            foreach (Correction correction in requests)
            {
                var newGetViewModel = new CorrectionGetViewModel(correction.CorrectionId);
                newGetViewModel.CorrectionCode = correction.CorrectionCode;
                newGetViewModel.CorrectionName = correction.CorrectionName;
                newGetViewModel.CorrectionType = Enum.GetName(typeof(ESolutionType), correction.CorrectionType);
                newGetViewModel.EstProcessTime = correction.EstProcessTime;
                newGetViewModel.Note = correction.Note;
                listGetViewModel.Add(newGetViewModel);
            }

            var queryResult = new QueryResult<CorrectionGetViewModel>(listGetViewModel, totalItems);

            return _mapper.Map<QueryResult<CorrectionGetViewModel>, QueryResult<CorrectionViewModel>>(queryResult);
        }
    }
}
