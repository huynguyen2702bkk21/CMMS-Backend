using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate;
using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate.MaintenanceResponse;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.MoldAggregate;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Domain.AggregateModels.SoundAggregate;
using Azure.Core;

namespace WebAPICHATest.Api.Application.Commands.MaintenanceRequests
{
    public class CreateMaintenanceRequestCommandHandler : IRequestHandler<CreateMaintenanceRequestCommand, bool>
    {
        private readonly IMaintenanceRequestRepository _maintenanceRequestRepository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMoldRepository _moldRepository;
        private readonly IImageRepository _imageRepository;
        private readonly ISoundRepository _soundRepository;

        public CreateMaintenanceRequestCommandHandler(IMaintenanceRequestRepository maintenanceRequestRepository, 
                                                      IEquipmentRepository equipmentRepository, 
                                                      IPersonRepository personRepository,
                                                      IMoldRepository moldRepository,
                                                      IImageRepository imageRepository,
                                                      ISoundRepository soundRepository)
        {
            _maintenanceRequestRepository = maintenanceRequestRepository;
            _equipmentRepository = equipmentRepository;
            _personRepository = personRepository;
            _moldRepository = moldRepository;
            _imageRepository = imageRepository;
            _soundRepository = soundRepository;
        }

        public async Task<bool> Handle(CreateMaintenanceRequestCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Through");
            EMaintenanceObject maintenanceObject;
            Enum.TryParse<EMaintenanceObject>(request.MaintenanceObject, out maintenanceObject);

            EMaintenanceRequestStatus status;
            Enum.TryParse<EMaintenanceRequestStatus>(request.Status, out status);

            EMaintenanceType type;
            Enum.TryParse<EMaintenanceType>(request.Type, out type);

            Console.WriteLine("1");
            Equipment? equipment = null;
            Mold? mold = null;
            if (request.Equipment != null || request.Mold != null)
            {
                if (maintenanceObject == MaintenanceResponse.EMaintenanceObject.equipment)
                {
                    equipment = await _equipmentRepository.GetByCode(request.Equipment) ?? throw new NotFoundException();
                }
                else if (maintenanceObject == MaintenanceResponse.EMaintenanceObject.mold)
                {
                    mold = await _moldRepository.GetByCode(request.Mold) ?? throw new NotFoundException();
                }
            }

            var requester = await _personRepository.GetById(request.Requester) ?? throw new NotFoundException();

            Console.WriteLine("3");
            Person? reviewer = null;
            if (request.Reviewer != null)
            {
                reviewer = await _personRepository.GetById(request.Reviewer) ?? throw new NotFoundException();

            }

            Console.WriteLine("4");
            Person? responsiblePerson = null;
            if (request.ResponsiblePerson != null)
            {
                responsiblePerson = await _personRepository.GetById(request.ResponsiblePerson) ?? throw new NotFoundException();

            }

            Console.WriteLine("5");
            string? listImage = null;
            if (request.Images != null)
            {
                listImage = "";
                foreach (string imageTemp in request.Images)
                {
                    listImage += imageTemp + "|";
                }
            }

            Console.WriteLine("6");
            string? listSound = null;
            if (request.Sounds != null)
            {
                listSound = "";
                foreach (string soundTemp in request.Sounds)
                {
                    listSound += soundTemp + "|";
                }
            }

            var genMaintenanceRequestId = Guid.NewGuid().ToString();
            var maintenanceRequests = await _maintenanceRequestRepository.GetAll();
            var code = $"MREQ-23{(maintenanceRequests.Count + 1).ToString().PadLeft(4, '0')}";
            var maintenanceRequest = new MaintenanceRequest(maintenanceRequestId: genMaintenanceRequestId,
                                                            code: code,
                                                            problem: request.Problem,
                                                            requestedCompletionDate: request.RequestedCompletionDate, 
                                                            requestedPriority: request.RequestedPriority,
                                                            requester: requester,
                                                            status: EMaintenanceRequestStatus.submitted,
                                                            reviewer: reviewer,
                                                            submissionDate: DateTime.UtcNow,
                                                            createdAt: DateTime.UtcNow,
                                                            updatedAt: DateTime.UtcNow,
                                                            type: type,
                                                            maintenanceObject: maintenanceObject,
                                                            equipment: equipment,
                                                            mold: mold,
                                                            images: listImage,
                                                            sounds: listSound,
                                                            responsiblePerson: responsiblePerson,
                                                            estProcessingTime: request.EstProcessingTime,
                                                            plannedStart: request.PlannedStart);

            _maintenanceRequestRepository.Add(maintenanceRequest);

            return await _maintenanceRequestRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
