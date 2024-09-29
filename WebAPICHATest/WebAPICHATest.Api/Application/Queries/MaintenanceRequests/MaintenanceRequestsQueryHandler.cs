using Microsoft.Identity.Client;
using System.Globalization;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Api.Application.Queries.MaintenanceRequests;
using WebAPICHATest.Domain.AggregateModels.CauseAggregate;
using WebAPICHATest.Domain.AggregateModels.CorrectionAggregate;
using WebAPICHATest.Domain.AggregateModels.EquipmentAggregate;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Domain.AggregateModels.JsonEquipmentAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.SoundAggregate;
using WebAPICHATest.Infrastructure;
using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate.MaintenanceResponse;

namespace WebAPICHATest.Api.Application.Queries.MaintenanceRequests
{
    public class MaintenanceRequestsQueryHandler : IRequestHandler<MaintenanceRequestsQuery, List<MaintenanceRequestViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MaintenanceRequestsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MaintenanceRequestViewModel>> Handle(MaintenanceRequestsQuery request, CancellationToken cancellationToken)
        {
            EMaintenanceRequestStatus status;
            Enum.TryParse<EMaintenanceRequestStatus>(request.Status, out status);

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

            var result = new List<MaintenanceRequest>();
            if (request.Status != null)
            {
                result = await _context.MaintenanceRequests
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
                                       .AsNoTracking()
                                       .Where(x => x.CreatedAt >= startDateLocal && x.CreatedAt <= endDateLocal)
                                       .Where(x => x.Status == status)
                                       .OrderBy(x => x.Status)
                                       .ThenByDescending(x => x.CreatedAt)
                                       .ToListAsync();
            }
            else
            {
                result = await _context.MaintenanceRequests
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
                                       .AsNoTracking()
                                       .Where(x => x.CreatedAt >= startDateLocal && x.CreatedAt <= endDateLocal)
                                       .OrderBy(x => x.Status)
                                       .ThenByDescending(x => x.CreatedAt)
                                       .ToListAsync();
            }
                

            var listGetViewModel = new List<MaintenanceRequestGetViewModel>();
            foreach (MaintenanceRequest response in result)
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

            return _mapper.Map<List<MaintenanceRequestGetViewModel>, List<MaintenanceRequestViewModel>>(listGetViewModel);
        }
    }
}
