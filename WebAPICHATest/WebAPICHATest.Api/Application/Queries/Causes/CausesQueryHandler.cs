using Azure;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Api.Application.Queries.Causes;
using WebAPICHATest.Domain.AggregateModels.CauseAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Infrastructure;
using WebAPICHATest.Infrastructure.Repositories;
using static WebAPICHATest.Domain.AggregateModels.CauseAggregate.Cause;
using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate.MaintenanceResponse;

namespace WebAPICHATest.Api.Application.Queries.Causes
{
    public class CausesQueryHandler : IRequestHandler<CausesQuery, List<CauseViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMaintenanceResponseRepository _maintenanceResponseRepository;

        public CausesQueryHandler(ApplicationDbContext context, IMapper mapper,
                                  IMaintenanceResponseRepository maintenanceResponseRepository)
        {
            _context = context;
            _mapper = mapper;
            _maintenanceResponseRepository = maintenanceResponseRepository;
        }

        public async Task<List<CauseViewModel>> Handle(CausesQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Causes
                .Include(x => x.MaintenanceResponses)
                .ThenInclude(x => x.Correction)

                .Include(x => x.MaintenanceResponses)
                .Include(x => x.MaintenanceResponses)
                .ThenInclude(x => x.ResponsiblePerson)

                .Include(x => x.MaintenanceResponses)
                .ThenInclude(x => x.Materials)
                .ThenInclude(x => x.MaterialInfor)

                .Include(x => x.MaintenanceResponses)
                .ThenInclude(x => x.Equipment)

                .Include(x => x.MaintenanceResponses)
                .ThenInclude(x => x.Mold)
                .AsNoTracking()
                .ToListAsync();

            var listGetViewModel = new List<CauseGetViewModel>();
            foreach (Cause cause in result)
            {
                var newGetViewModel = new CauseGetViewModel(cause.CauseId);
                newGetViewModel.CauseCode = cause.CauseCode;
                newGetViewModel.CauseName = cause.CauseName;
                newGetViewModel.EquipmentType = Enum.GetName(typeof(EMaintenanceObject), cause.MaintenanceObject);
                newGetViewModel.Severity = Enum.GetName(typeof(ECauseSeverity), cause.Severity);
                newGetViewModel.Note = cause.Note;
                listGetViewModel.Add(newGetViewModel);
            }

            return _mapper.Map<List<CauseGetViewModel>, List<CauseViewModel>>(listGetViewModel);
        }
    }
}
