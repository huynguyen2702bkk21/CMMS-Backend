using WebAPICHATest.Api.Application.Queries.Causes;
using WebAPICHATest.Domain.AggregateModels.CauseAggregate;
using WebAPICHATest.Infrastructure;
using static WebAPICHATest.Domain.AggregateModels.CauseAggregate.Cause;
using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate.MaintenanceResponse;

namespace WebAPICHATest.Api.Application.Queries.Causes
{
    public class CauseByIdQueryHandler : IRequestHandler<CauseByIdQuery, QueryResult<CauseViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CauseByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<CauseViewModel>> Handle(CauseByIdQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.Causes
                .Include(x => x.MaintenanceResponses)
                .AsNoTracking();

            if (request.CauseId is not null)
            {
                queryable = queryable.Where(x => x.CauseId == request.CauseId);
            }

            int totalItems = await queryable.CountAsync();

            queryable = queryable
                .OrderBy(x => x.CauseId)
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize);

            var requests = await queryable.ToListAsync();
            var listGetViewModel = new List<CauseGetViewModel>();
            foreach (Cause cause in requests)
            {
                var newGetViewModel = new CauseGetViewModel(cause.CauseId);
                newGetViewModel.CauseCode = cause.CauseCode;
                newGetViewModel.CauseName = cause.CauseName;
                newGetViewModel.EquipmentType = Enum.GetName(typeof(EMaintenanceObject), cause.MaintenanceObject);
                newGetViewModel.Severity = Enum.GetName(typeof(ECauseSeverity), cause.Severity);
                newGetViewModel.Note = cause.Note;
                listGetViewModel.Add(newGetViewModel);
            }
            var queryResult = new QueryResult<CauseGetViewModel>(listGetViewModel, totalItems);

            return _mapper.Map<QueryResult<CauseGetViewModel>, QueryResult<CauseViewModel>>(queryResult);
        }
    }
}
