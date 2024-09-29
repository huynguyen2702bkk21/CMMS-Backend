using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.CauseAggregate;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Domain.AggregateModels.CorrectionAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
using WebAPICHATest.Domain.AggregateModels.SoundAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.MoldAggregate;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate.MaintenanceResponse;
using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;
using WebAPICHATest.Domain.ConstantDomain;
using WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate;
using WebAPICHATest.Infrastructure.Repositories;

namespace WebAPICHATest.Api.Application.Commands.MaintenanceResponses
{
    public class CreateMaintenanceResponseCommandHandler : IRequestHandler<CreateMaintenanceResponseCommand, bool>
    {
        private readonly IMaintenanceResponseRepository _maintenanceResponseRepository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IImageRepository _imageRepository;
        private readonly ISoundRepository _soundRepository;
        private readonly ICauseRepository _causeRepository;
        private readonly ICorrectionRepository _correctionRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IMoldRepository _moldRepository;
        public CreateMaintenanceResponseCommandHandler(IMaintenanceResponseRepository maintenanceResponseRepository,
                                                       IEquipmentRepository equipmentRepository,
                                                       IPersonRepository personRepository,
                                                       IImageRepository imageRepository,
                                                       ISoundRepository soundRepository,
                                                       ICauseRepository causeRepository,
                                                       ICorrectionRepository correctionRepository,
                                                       IMaterialRepository materialRepository,
                                                       IMoldRepository moldRepository)
        {
            _maintenanceResponseRepository = maintenanceResponseRepository;
            _equipmentRepository = equipmentRepository;
            _personRepository = personRepository;
            _imageRepository = imageRepository;
            _soundRepository = soundRepository;
            _causeRepository = causeRepository;
            _correctionRepository = correctionRepository;
            _materialRepository = materialRepository;
            _moldRepository = moldRepository;
        }

        public async Task<bool> Handle(CreateMaintenanceResponseCommand request, CancellationToken cancellationToken)
        {
            EMaintenanceObject maintenanceObject;
            Enum.TryParse<EMaintenanceObject>(request.MaintenanceObject, out maintenanceObject);

            EMaintenanceStatus status;
            Enum.TryParse<EMaintenanceStatus>(request.Status, out status);

            EMaintenanceType type;
            Enum.TryParse<EMaintenanceType>(request.Type, out type);

            Equipment? equipment = null;
            Mold? mold = null;
            if (maintenanceObject == MaintenanceResponse.EMaintenanceObject.equipment)
            {
                equipment = await _equipmentRepository.GetById(request.Equipment) ?? throw new NotFoundException();
            }
            else if(maintenanceObject == MaintenanceResponse.EMaintenanceObject.mold)
            {
                mold = await _moldRepository.GetById(request.Mold) ?? throw new NotFoundException();
            }
            var responsiblePerson = await _personRepository.GetById(request.ResponsiblePerson) ?? throw new NotFoundException();

            var maintenanceResponseId = Guid.NewGuid().ToString();

            var maintenanceResponses = await _maintenanceResponseRepository?.GetAll();
            var code = $"MRES-23{(maintenanceResponses.Count + 1).ToString().PadLeft(4, '0')}";

            var maintenanceResponse = new MaintenanceResponse(maintenanceResponseId: maintenanceResponseId,
                                                              cause: null, 
                                                              correction: null, 
                                                              plannedStart: request.PlannedStart, 
                                                              plannedFinish: request.PlannedFinish, 
                                                              estProcessTime: request.EstProcessTime,
                                                              actualStartTime: request.ActualStartTime,
                                                              actualFinishTime: request.ActualFinishTime, 
                                                              status: status,
                                                              createdAt: DateTime.UtcNow,
                                                              updatedAt: DateTime.UtcNow,
                                                              responsiblePerson: responsiblePerson,
                                                              priority: request.Priority, 
                                                              problem: request.Problem, 
                                                              images: null, 
                                                              sounds: null,
                                                              materials: null,
                                                              code: code,
                                                              note: request.Note,
                                                              request: null,
                                                              maintenanceObject: maintenanceObject,
                                                              equipment: equipment,
                                                              mold: mold,
                                                              dueDate: request.DueDate,
                                                              type: type);

            _maintenanceResponseRepository.Add(maintenanceResponse);

            return await _maintenanceResponseRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
