using WebAPICHATest.Api.Application.Queries.MaterialRequests;
using WebAPICHATest.Api.Application.Queries.MaterialRequests;
using WebAPICHATest.Domain.AggregateModels.MaterialRequestAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialRequestAggregate;
using WebAPICHATest.Infrastructure;
using System.Globalization;
using static WebAPICHATest.Domain.AggregateModels.MaterialRequestAggregate.MaterialRequest;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate.MaintenanceResponse;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;

namespace WebAPICHATest.Api.Application.Queries.MaterialRequests
{
    public class MaterialRequestsQueryHandler : IRequestHandler<MaterialRequestsQuery, List<MaterialRequestViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MaterialRequestsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MaterialRequestViewModel>> Handle(MaterialRequestsQuery request, CancellationToken cancellationToken)
        {
            EMaterialRequestStatus status;
            Enum.TryParse<EMaterialRequestStatus>(request.Status, out status);

            DateTime? startDateLocal = DateTime.ParseExact("01/01/1970", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime? endDateLocal = DateTime.ParseExact("01/01/2100", "dd/MM/yyyy", CultureInfo.InvariantCulture);

            if (request.StartDate is not null)
            {
                startDateLocal = request.StartDate;
            }

            if (request.EndDate is not null)
            {
                endDateLocal = request.EndDate;
            }

            var result = new List<MaterialRequest>();
            if (request.Status != null)
            {
                result = await _context.MaterialRequests
                           .Include(x => x.MaterialInfor)
                           .AsNoTracking()
                           .Where(x => x.CreatedAt >= startDateLocal && x.CreatedAt <= endDateLocal)
                           .Where(x => x.Status == status)
                           .OrderByDescending(x => x.Status != EMaterialRequestStatus.completed)
                           .ThenByDescending(x => x.CreatedAt)
                           .ToListAsync();
            }
            else
            {
                result = await _context.MaterialRequests
                           .Include(x => x.MaterialInfor)
                           .AsNoTracking()
                           .Where(x => x.CreatedAt >= startDateLocal && x.CreatedAt <= endDateLocal)
                           .OrderByDescending(x => x.Status != EMaterialRequestStatus.completed)
                           .ThenByDescending(x => x.CreatedAt)
                           .ToListAsync();
            }


            var listGetViewModel = new List<MaterialRequestGetViewModel>();
            foreach (MaterialRequest materialRequest in result)
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

            return _mapper.Map<List<MaterialRequestGetViewModel>, List<MaterialRequestViewModel>>(listGetViewModel);
        }
    }
}
