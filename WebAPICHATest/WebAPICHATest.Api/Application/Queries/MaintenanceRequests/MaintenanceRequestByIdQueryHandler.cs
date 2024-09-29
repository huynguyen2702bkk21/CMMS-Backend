using WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate;
using WebAPICHATest.Domain.AggregateModels.SoundAggregate;
using WebAPICHATest.Infrastructure;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate.MaintenanceResponse;

namespace WebAPICHATest.Api.Application.Queries.MaintenanceRequests
{
    public class MaintenanceRequestByIdQueryHandler : IRequestHandler<MaintenanceRequestByIdQuery, QueryResult<MaintenanceRequestViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MaintenanceRequestByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QueryResult<MaintenanceRequestViewModel>> Handle(MaintenanceRequestByIdQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.MaintenanceRequests
                .Include(x => x.Requester)
                .Include(x => x.Reviewer)
                .Include(x => x.Equipment)
                .ThenInclude(x => x.MTBF)

                .Include(x => x.Equipment)
                .ThenInclude(x => x.MTTF)

                .Include(x => x.Equipment)
                .ThenInclude(x => x.OEE)

                .Include(x => x.Equipment)
                .ThenInclude(x => x.Materials)
                .ThenInclude(x => x.MaterialInfor)

                .Include(x => x.Mold)
                .Include(x => x.ResponsiblePerson)
                .AsNoTracking();

            if (request.MaintenanceRequestId is not null)
            {
                queryable = queryable.Where(x => x.MaintenanceRequestId == request.MaintenanceRequestId);
            }

            int totalItems = await queryable.CountAsync();

            queryable = queryable
                .OrderBy(x => x.MaintenanceRequestId)
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize);

            var requests = await queryable.ToListAsync();

            var listGetViewModel = new List<MaintenanceRequestGetViewModel>();
            foreach (MaintenanceRequest response in requests)
            {
                var newGetViewModel = new MaintenanceRequestGetViewModel(response.MaintenanceRequestId);
                newGetViewModel.Code = response.Code;
                newGetViewModel.Problem = response.Problem;
                newGetViewModel.RequestedCompletionDate = response.RequestedCompletionDate;
                newGetViewModel.RequestedPriority = response.RequestedPriority;
                if (response.Requester != null)
                {
                    newGetViewModel.Requester = response.Requester;
                    newGetViewModel.Requester.ScheduleWorkingTimes = null;
                }
                newGetViewModel.Status = Enum.GetName(typeof(EMaintenanceRequestStatus), response.Status);
                if (response.Reviewer != null)
                {
                    newGetViewModel.Reviewer = response.Reviewer;
                    newGetViewModel.Reviewer.ScheduleWorkingTimes = null;
                }
                newGetViewModel.SubmissionDate = response.SubmissionDate;
                newGetViewModel.CreatedAt = response.CreatedAt;
                newGetViewModel.UpdatedAt = response.UpdatedAt;
                newGetViewModel.Type = Enum.GetName(typeof(EMaintenanceType), response.Type);
                newGetViewModel.MaintenanceObject = Enum.GetName(typeof(EMaintenanceObject), response.MaintenanceObject);
                newGetViewModel.Equipment = response.Equipment;
                if (newGetViewModel.Equipment != null)
                {
                    if (newGetViewModel.Equipment.ScheduleWorkingTimes != null)
                    {
                        newGetViewModel.Equipment.ScheduleWorkingTimes = null;
                    }
                }

                newGetViewModel.Mold = response.Mold;
                if (newGetViewModel.Mold != null)
                {
                    if (newGetViewModel.Mold.ScheduleWorkingTimes != null)
                    {
                        newGetViewModel.Mold.ScheduleWorkingTimes = null;
                    }
                }

                List<string>? listImageString = null;
                if (string.IsNullOrEmpty(response.Images) == false)
                {
                    listImageString = response.Images.Split("|").ToList();
                    listImageString.RemoveAt(listImageString.Count - 1);
                }
                newGetViewModel.Images = listImageString;

                List<string>? listSoundString = null;
                if (string.IsNullOrEmpty(response.Sounds) == false)
                {
                    listSoundString = response.Sounds.Split("|").ToList();
                    listSoundString.RemoveAt(listSoundString.Count - 1);
                }
                newGetViewModel.Sounds = listSoundString;

                newGetViewModel.ResponsiblePerson = response.ResponsiblePerson;
                if (newGetViewModel.ResponsiblePerson != null)
                {
                    if (newGetViewModel.ResponsiblePerson.ScheduleWorkingTimes != null)
                    {
                        newGetViewModel.ResponsiblePerson.ScheduleWorkingTimes = null;
                    }
                }

                newGetViewModel.EstProcessingTime = response.EstProcessingTime;
                newGetViewModel.PlannedStart = response.PlannedStart;
                listGetViewModel.Add(newGetViewModel);
            }

            var queryResult = new QueryResult<MaintenanceRequestGetViewModel>(listGetViewModel, totalItems);

            return _mapper.Map<QueryResult<MaintenanceRequestGetViewModel>, QueryResult<MaintenanceRequestViewModel>>(queryResult);
        }
    }
}
