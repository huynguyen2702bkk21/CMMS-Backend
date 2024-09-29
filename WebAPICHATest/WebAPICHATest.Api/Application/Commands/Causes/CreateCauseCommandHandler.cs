using WebAPICHATest.Api.Application.Commands.Causes;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.CauseAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using static WebAPICHATest.Domain.AggregateModels.CauseAggregate.Cause;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate.MaintenanceResponse;

namespace WebAPICHATest.Api.Application.Commands.Causes
{
    public class CreateCauseCommandHandler : IRequestHandler<CreateCauseCommand, bool>
    {
        private readonly ICauseRepository _causeRepository;
        private readonly IMaintenanceResponseRepository _maintenanceResponseRepository;

        public CreateCauseCommandHandler(ICauseRepository causeRepository,
                                         IMaintenanceResponseRepository maintenanceResponseRepository)
        {
            _causeRepository = causeRepository;
            _maintenanceResponseRepository = maintenanceResponseRepository;
        }

        public async Task<bool> Handle(CreateCauseCommand request, CancellationToken cancellationToken)
        {
            //var maintenanceResponse = await _maintenanceResponseRepository.GetById(request.MaintenanceResponse) ?? throw new NotFoundException();
            EMaintenanceObject maintenanceObject;
            Enum.TryParse<EMaintenanceObject>(request.MaintenanceObject, out maintenanceObject);

            ECauseSeverity severity;
            Enum.TryParse<ECauseSeverity>(request.Severity, out severity);

            string causeId = Guid.NewGuid().ToString();
            var listCause = await _causeRepository.GetAll();
            var causeCode = $"CAU-{(listCause.Count + 1).ToString().PadLeft(4, '0')}";
            var cause = new Cause(causeId: causeId, 
                                  causeCode: causeCode, 
                                  causeName: request.CauseName, 
                                  maintenanceObject: maintenanceObject, 
                                  severity: severity, 
                                  note: request.Note);
            _causeRepository.Add(cause);

            return await _causeRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
