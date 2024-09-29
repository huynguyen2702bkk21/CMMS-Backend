using WebAPICHATest.Api.Application.Commands.Corrections;
using WebAPICHATest.Domain.AggregateModels.CorrectionAggregate;
using static WebAPICHATest.Domain.AggregateModels.CauseAggregate.Cause;
using static WebAPICHATest.Domain.AggregateModels.CorrectionAggregate.Correction;

namespace WebAPICHATest.Api.Application.Commands.Corrections
{
    public class CreateCorrectionCommandHandler : IRequestHandler<CreateCorrectionCommand, bool>
    {
        private readonly ICorrectionRepository _correctionRepository;

        public CreateCorrectionCommandHandler(ICorrectionRepository correctionRepository)
        {
            _correctionRepository = correctionRepository;
        }

        public async Task<bool> Handle(CreateCorrectionCommand request, CancellationToken cancellationToken)
        {
            ESolutionType type;
            Enum.TryParse<ESolutionType>(request.CorrectionType, out type);

            string correctionId = Guid.NewGuid().ToString();
            var listCorrection = await _correctionRepository.GetAll();
            var correctionCode = $"COR-{(listCorrection.Count + 1).ToString().PadLeft(4, '0')}";

            var correction = new Correction(correctionId: correctionId,
                                            correctionCode: correctionCode,
                                            correctionName: request.CorrectionName,
                                            correctionType: type,
                                            estProcessTime: request.EstProcessTime,
                                            note: request.Note);

            _correctionRepository.Add(correction);

            return await _correctionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
