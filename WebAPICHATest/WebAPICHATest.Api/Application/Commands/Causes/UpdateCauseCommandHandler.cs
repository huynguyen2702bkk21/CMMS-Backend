using WebAPICHATest.Api.Application.Commands.Causes;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.CauseAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using static WebAPICHATest.Domain.AggregateModels.CauseAggregate.Cause;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate.MaintenanceResponse;

namespace WebAPICHATest.Api.Application.Commands.Causes
{
    public class UpdateCauseCommandHandler : IRequestHandler<UpdateCauseCommand, bool>
    {
        private readonly ICauseRepository _causeRepository;
        private readonly IMaintenanceResponseRepository _maintenanceResponseRepository;

        public UpdateCauseCommandHandler(ICauseRepository causeRepository,
                                         IMaintenanceResponseRepository maintenanceResponseRepository)
        {
            _causeRepository = causeRepository;
            _maintenanceResponseRepository = maintenanceResponseRepository;
        }

        public async Task<bool> Handle(UpdateCauseCommand request, CancellationToken cancellationToken)
        {
            //var maintenanceResponse = await _maintenanceResponseRepository.GetById(request.MaintenanceResponse) ?? throw new NotFoundException();
            var cause = await _causeRepository.GetById(request.CauseId) ?? throw new NotFoundException();
            EMaintenanceObject maintenanceObject;
            Enum.TryParse<EMaintenanceObject>(request.MaintenanceObject, out maintenanceObject);

            ECauseSeverity severity;
            Enum.TryParse<ECauseSeverity>(request.Severity, out severity);

            cause.Update(request.CauseCode, request.CauseName, maintenanceObject, severity, request.Note);
            _causeRepository.Update(cause);

            return await _causeRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
