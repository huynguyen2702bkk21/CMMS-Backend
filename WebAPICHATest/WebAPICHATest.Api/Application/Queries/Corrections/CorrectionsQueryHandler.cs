using WebAPICHATest.Api.Application.Queries.Causes;
using WebAPICHATest.Api.Application.Queries.Corrections;
using WebAPICHATest.Domain.AggregateModels.CorrectionAggregate;
using WebAPICHATest.Infrastructure;
using static WebAPICHATest.Domain.AggregateModels.CauseAggregate.Cause;
using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;

namespace WebAPICHATest.Api.Application.Queries.Corrections
{
    public class CorrectionsQueryHandler : IRequestHandler<CorrectionsQuery, List<CorrectionViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CorrectionsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CorrectionViewModel>> Handle(CorrectionsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Corrections
                .Include(x => x.MaintenanceResponses)
                .AsNoTracking().ToListAsync();

            var listGetViewModel = new List<CorrectionGetViewModel>();
            foreach (Correction correction in result)
            {
                var newGetViewModel = new CorrectionGetViewModel(correction.CorrectionId);
                newGetViewModel.CorrectionCode = correction.CorrectionCode;
                newGetViewModel.CorrectionName = correction.CorrectionName;
                newGetViewModel.CorrectionType = Enum.GetName(typeof(ESolutionType), correction.CorrectionType);
                newGetViewModel.EstProcessTime = correction.EstProcessTime;
                newGetViewModel.Note = correction.Note;

                listGetViewModel.Add(newGetViewModel);
            }

            return _mapper.Map<List<CorrectionGetViewModel>, List<CorrectionViewModel>>(listGetViewModel);
        }
    }
}
