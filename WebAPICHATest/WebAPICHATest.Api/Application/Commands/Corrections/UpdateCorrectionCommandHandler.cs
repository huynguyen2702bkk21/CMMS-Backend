using WebAPICHATest.Api.Application.Commands.Corrections;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.CorrectionAggregate;
using static WebAPICHATest.Domain.AggregateModels.CauseAggregate.Cause;

namespace WebAPICHATest.Api.Application.Commands.Corrections
{
    public class UpdateCorrectionCommandHandler : IRequestHandler<UpdateCorrectionCommand, bool>
    {
        private readonly ICorrectionRepository _correctionRepository;

        public UpdateCorrectionCommandHandler(ICorrectionRepository correctionRepository)
        {
            _correctionRepository = correctionRepository;
        }

        public async Task<bool> Handle(UpdateCorrectionCommand request, CancellationToken cancellationToken)
        {
            var correction = await _correctionRepository.GetById(request.CorrectionId) ?? throw new NotFoundException();
            ESolutionType type;
            Enum.TryParse<ESolutionType>(request.CorrectionType, out type);

            correction.Update(request.CorrectionCode, request.CorrectionName, type, request.EstProcessTime, request.Note);
            _correctionRepository.Update(correction);

            return await _correctionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
