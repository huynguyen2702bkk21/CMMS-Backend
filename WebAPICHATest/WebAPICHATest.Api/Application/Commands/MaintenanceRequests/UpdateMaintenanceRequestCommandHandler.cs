using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate;
using WebAPICHATest.Infrastructure.Repositories;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;
using WebAPICHATest.Domain.AggregateModels.MoldAggregate;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate.MaintenanceResponse;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Domain.AggregateModels.SoundAggregate;
using System.Reflection.Metadata;
using System;

namespace WebAPICHATest.Api.Application.Commands.MaintenanceRequests
{
    public class UpdateMaintenanceRequestCommandHandler : IRequestHandler<UpdateMaintenanceRequestCommand, bool>
    {
        private readonly IMaintenanceRequestRepository _maintenanceRequestRepository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMoldRepository _moldRepository;
        private readonly IImageRepository _imageRepository;
        private readonly ISoundRepository _soundRepository;
        private readonly IMaintenanceResponseRepository _maintenanceResponseRepository;

        public UpdateMaintenanceRequestCommandHandler(IMaintenanceRequestRepository maintenanceRequestRepository,
                                                      IEquipmentRepository equipmentRepository,
                                                      IPersonRepository personRepository,
                                                      IMoldRepository moldRepository,
                                                      IImageRepository imageRepository,
                                                      ISoundRepository soundRepository,
                                                      IMaintenanceResponseRepository maintenanceResponseRepository)
        {
            _maintenanceRequestRepository = maintenanceRequestRepository;
            _equipmentRepository = equipmentRepository;
            _personRepository = personRepository;
            _moldRepository = moldRepository;
            _imageRepository = imageRepository;
            _soundRepository = soundRepository;
            _maintenanceResponseRepository = maintenanceResponseRepository;
        }

        public async Task<bool> Handle(UpdateMaintenanceRequestCommand request, CancellationToken cancellationToken)
        {
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


            Console.WriteLine("2");
            Person? requester = null;
            if (request.Requester != null)
            {
                requester = await _personRepository.GetById(request.Requester) ?? throw new NotFoundException();

            }

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


            Console.WriteLine("7");
            var maintenanceRequest = await _maintenanceRequestRepository.GetById(request.MaintenanceRequestId) ?? throw new NotFoundException();
            Console.WriteLine("8");

            if (status == EMaintenanceRequestStatus.approved)
            {
                string newMaintenanceResponseId = Guid.NewGuid().ToString();
                var maintenanceResponses = await _maintenanceResponseRepository?.GetAll();
                var code = $"MRES-23{(maintenanceResponses.Count + 1).ToString().PadLeft(4, '0')}";
                var estProcessTime = maintenanceRequest.EstProcessingTime;
                var plannedStart = maintenanceRequest.PlannedStart;
                var problem = maintenanceRequest.Problem;
                var priority = maintenanceRequest.RequestedPriority;
                var maintenanceType = maintenanceRequest.Type;
                var maintenanceRequestId = maintenanceRequest.MaintenanceRequestId;
                Person? person = null;
                if (request.ResponsiblePerson != null)
                {
                    person = await _personRepository.GetById(request.ResponsiblePerson) ?? throw new NotFoundException();
                }
                else if(maintenanceRequest.ResponsiblePerson != null)
                {
                    person = await _personRepository.GetById(maintenanceRequest.ResponsiblePerson.PersonId) ?? throw new NotFoundException(); 
                }

                var maintenanceResponse = new MaintenanceResponse(maintenanceResponseId: newMaintenanceResponseId,
                                                                  cause: null,
                                                                  correction: null,
                                                                  plannedStart: plannedStart,
                                                                  plannedFinish: null,
                                                                  estProcessTime: estProcessTime,
                                                                  actualStartTime: null,
                                                                  actualFinishTime: null,
                                                                  status: Equipment.EMaintenanceStatus.assigned,
                                                                  createdAt: DateTime.UtcNow,
                                                                  updatedAt: DateTime.UtcNow,
                                                                  responsiblePerson: person,
                                                                  priority: priority,
                                                                  problem: problem,
                                                                  images: null,
                                                                  sounds: null,
                                                                  materials: null,
                                                                  code: code,
                                                                  note: null,
                                                                  request: maintenanceRequest,
                                                                  maintenanceObject: maintenanceObject,
                                                                  equipment: equipment,
                                                                  mold: mold,
                                                                  dueDate: null,
                                                                  type: maintenanceType);
                _maintenanceResponseRepository.Add(maintenanceResponse);
            }


            maintenanceRequest.Update(code: request.Code,
                                      problem: request.Problem,
                                      requestedCompletionDate: request.RequestedCompletionDate,
                                      requestedPriority: request.RequestedPriority,
                                      requester: requester,
                                      status: status,
                                      reviewer: reviewer,
                                      submissionDate: request.SubmissionDate,
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
            Console.WriteLine("9");
            _maintenanceRequestRepository.Update(maintenanceRequest);
            Console.WriteLine("10");
            return await _maintenanceRequestRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
