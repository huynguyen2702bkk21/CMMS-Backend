using WebAPICHATest.Api.Application.Queries.MaterialRequests;
using WebAPICHATest.Domain.AggregateModels.CauseAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialRequestAggregate;
using WebAPICHATest.Infrastructure;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate.MaintenanceResponse;
using static WebAPICHATest.Domain.AggregateModels.MaterialRequestAggregate.MaterialRequest;

namespace WebAPICHATest.Api.Application.Queries.MaterialRequests
{
    public class MaterialRequestByIdQueryHandler : IRequestHandler<MaterialRequestByIdQuery, QueryResult<MaterialRequestViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MaterialRequestByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<MaterialRequestViewModel>> Handle(MaterialRequestByIdQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.MaterialRequests
                .Include(x => x.MaterialInfor)
                .AsNoTracking();

            if (request.MaterialRequestId is not null)
            {
                queryable = queryable.Where(x => x.MaterialRequestId == request.MaterialRequestId);
            }

            int totalItems = await queryable.CountAsync();

            queryable = queryable
                .OrderBy(x => x.MaterialRequestId)
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize);

            var requests = await queryable.ToListAsync();
            var listGetViewModel = new List<MaterialRequestGetViewModel>();
            foreach (MaterialRequest materialRequest in requests)
            {
                var newGetViewModel = new MaterialRequestGetViewModel(materialRequest.MaterialRequestId);
                newGetViewModel.Code = materialRequest.Code;
                newGetViewModel.MaterialInfor = materialRequest.MaterialInfor;
                newGetViewModel.CurrentNumber = materialRequest.CurrentNumber;
                newGetViewModel.AdditionalNumber = materialRequest.AdditionalNumber;
                newGetViewModel.ExpectedNumber = materialRequest.ExpectedNumber;
                newGetViewModel.ExpectedDate = materialRequest.ExpectedDate;
                newGetViewModel.CreatedAt = materialRequest.CreatedAt;
                newGetViewModel.UpdatedAt = materialRequest.UpdatedAt;
                newGetViewModel.Status = Enum.GetName(typeof(EMaterialRequestStatus), materialRequest.Status);
                listGetViewModel.Add(newGetViewModel);
            }

            var queryResult = new QueryResult<MaterialRequestGetViewModel>(listGetViewModel, totalItems);

            return _mapper.Map<QueryResult<MaterialRequestGetViewModel>, QueryResult<MaterialRequestViewModel>>(queryResult);
        }
    }
}
