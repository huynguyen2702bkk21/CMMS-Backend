using WebAPICHATest.Api.Application.Commands.MaintenanceResponses;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.CauseAggregate;
using WebAPICHATest.Domain.AggregateModels.CorrectionAggregate;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Domain.AggregateModels.InspectionReportAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialHistoryCardAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialRequestAggregate;
using WebAPICHATest.Domain.AggregateModels.MoldAggregate;
using WebAPICHATest.Domain.AggregateModels.NotificationAggregate;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
using WebAPICHATest.Domain.AggregateModels.SoundAggregate;
using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;
using static WebAPICHATest.Domain.AggregateModels.InspectionReportAggregate.InspectionReport;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate.MaintenanceResponse;


namespace WebAPICHATest.Api.Application.Commands.MaintenanceResponses
{
    public class UpdateMaintenanceResponseCommandHandler : IRequestHandler<UpdateMaintenanceResponseCommand, bool>
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
        private readonly IEquipmentMaterialRepository _equipmentMaterialRepository;
        private readonly IMaterialInforRepository _materialInforRepository;
        private readonly IInspectionReportRepository _inspectionReportRepository;

        public UpdateMaintenanceResponseCommandHandler(IMaintenanceResponseRepository maintenanceResponseRepository,
                                                       IEquipmentRepository equipmentRepository,
                                                       IPersonRepository personRepository,
                                                       IImageRepository imageRepository,
                                                       ISoundRepository soundRepository,
                                                       ICauseRepository causeRepository,
                                                       ICorrectionRepository correctionRepository,
                                                       IMaterialRepository materialRepository,
                                                       IMoldRepository moldRepository,
                                                       IEquipmentMaterialRepository equipmentMaterialRepository,
                                                       IMaterialInforRepository materialInforRepository,
                                                       IInspectionReportRepository inspectionReportRepository)
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
            _equipmentMaterialRepository = equipmentMaterialRepository;
            _materialInforRepository = materialInforRepository;
            _inspectionReportRepository = inspectionReportRepository;
        }

        public async Task<bool> Handle(UpdateMaintenanceResponseCommand request, CancellationToken cancellationToken)
        {
            var maintenanceResponse = await _maintenanceResponseRepository?.GetById(request.MaintenanceResponseId) ?? throw new NotFoundException();
            EMaintenanceStatus status;
            Enum.TryParse<EMaintenanceStatus>(request.Status, out status);
            Console.WriteLine("9");
            EMaintenanceObject maintenanceObject;
            Enum.TryParse<EMaintenanceObject>(request.MaintenanceObject, out maintenanceObject);

            EMaintenanceType type;
            Enum.TryParse<EMaintenanceType>(request.Type, out type);
            Console.WriteLine("10");
            Equipment? equipment = null;
            Mold? mold = null;
            if (request.Equipment != null || request.Mold != null)
            {
                if (maintenanceObject == MaintenanceResponse.EMaintenanceObject.equipment)
                {
                    equipment = await _equipmentRepository?.GetById(request.Equipment) ?? throw new NotFoundException();
                }
                else if (maintenanceObject == MaintenanceResponse.EMaintenanceObject.mold)
                {
                    mold = await _moldRepository?.GetById(request.Mold) ?? throw new NotFoundException();
                }
            }

            Console.WriteLine("1");
            Person? responsiblePerson = null;
            if (request.ResponsiblePerson!= null)
            {
                responsiblePerson = await _personRepository?.GetById(request.ResponsiblePerson) ?? throw new NotFoundException();
            }

            
            List<Cause>? listCause = null;
            if (request.Cause != null)
            {
                listCause = new List<Cause>();
                foreach (string causeTemp in request.Cause)
                {
                    var cause = await _causeRepository?.GetById(causeTemp) ?? throw new NotFoundException();
                    listCause.Add(cause);
                }
            }
            
            Console.WriteLine("2");
            List<Correction> listCorrection = null;
            if (request.Correction != null)
            {
                listCorrection = new List<Correction>();
                foreach (string correctionTemp in request.Correction)
                {
                    var correction = await _correctionRepository?.GetById(correctionTemp) ?? throw new NotFoundException();
                    listCorrection.Add(correction);
                }
            }

            Console.WriteLine("3");
            string? listImage = null;
            if (request.Images != null)
            {
                listImage = "";
                foreach (string imageTemp in request.Images)
                {
                    listImage += imageTemp + "|";
                }
            }

            Console.WriteLine("4");
            string? listSound = null;
            if (request.Sounds != null)
            {
                listSound = "";
                foreach (string soundTemp in request.Sounds)
                {
                    listSound += soundTemp + "|";
                }
            }

            Console.WriteLine("5");
            List<Material> listMaterial = null;
            if(request.Materials != null)
            {
                listMaterial = new List<Material>();
                foreach (string sku in request.Materials)
                {
                    var material = await _materialRepository?.GetBySku(sku) ?? throw new NotFoundException();
                    listMaterial.Add(material);
                }
            }

            Console.WriteLine("6");

            if (status == EMaintenanceStatus.completed)
            {
                if (maintenanceResponse.MaintenanceObject == EMaintenanceObject.equipment && maintenanceResponse.Materials != null)
                {
                    foreach (Material material in maintenanceResponse.Materials)
                    {
                        foreach (EquipmentMaterial equipmentMaterial in maintenanceResponse.Equipment.Materials)
                        {
                            if (material.MaterialInfor == equipmentMaterial.MaterialInfor)
                            {
                                var getEquipmentMaterial = await _equipmentMaterialRepository.GetById(equipmentMaterial.EquipmentMaterialId) ?? throw new NotFoundException();
                                getEquipmentMaterial.Update(materialInfor: null,
                                                            fullTime: null,
                                                            usedTime: 0,
                                                            installedTime: DateTime.UtcNow,
                                                            updateAt: DateTime.UtcNow);
                                _equipmentMaterialRepository.Update(getEquipmentMaterial);
                                await _equipmentMaterialRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                            }
                        }
                        material.Status = Material.MaterialStatus.inUsed;
                    }
                }

                Dictionary<MaterialInfor, decimal> materialInforDict = new Dictionary<MaterialInfor, decimal>();
                foreach (Material material in maintenanceResponse.Materials)
                {
                    if (materialInforDict.Count == 0)
                    {
                        materialInforDict.Add(material.MaterialInfor, 1);
                    }
                    else
                    {
                        foreach (MaterialInfor materialInfor in materialInforDict.Keys)
                        {
                            if (material.MaterialInfor == materialInfor)
                            {
                                materialInforDict[materialInfor] += 1;
                                break;
                            }
                            else
                            {
                                materialInforDict.Add(material.MaterialInfor, 1);
                                break;
                            }
                        }
                    }
                }

                foreach (MaterialInfor materialInfor in materialInforDict.Keys)
                {
                    var materialInforTemp = await _materialInforRepository.GetById(materialInfor.MaterialInforId) ?? throw new NotFoundException();
                    var card = MaterialHistoryCard.OutputMaterialHistoryCard(materialInforTemp, materialInforDict[materialInfor]);
                    materialInforTemp.MaterialHistoryCards.Add(card);
                    await _materialInforRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                }
            }

            //if (status == EMaintenanceStatus.inProgress)
            //{
            //    Dictionary<MaterialInfor, decimal> materialInforDict = new Dictionary<MaterialInfor, decimal>();
            //    foreach (Material material in maintenanceResponse.Materials)
            //    {
            //        if (materialInforDict.Count == 0)
            //        {
            //            materialInforDict.Add(material.MaterialInfor, 1);
            //        }
            //        else
            //        {
            //            foreach (MaterialInfor materialInfor in materialInforDict.Keys)
            //            {
            //                if (material.MaterialInfor == materialInfor)
            //                {
            //                    materialInforDict[materialInfor] += 1;
            //                    break;
            //                }
            //                else
            //                {
            //                    materialInforDict.Add(material.MaterialInfor, 1);
            //                    break;
            //                }
            //            }
            //        }
            //    }

            //    foreach(MaterialInfor materialInfor in materialInforDict.Keys)
            //    {
            //        var materialInforTemp = await _materialInforRepository.GetById(materialInfor.MaterialInforId) ?? throw new NotFoundException();
            //        var card = MaterialHistoryCard.OutputMaterialHistoryCard(materialInforTemp, materialInforDict[materialInfor]);
            //        materialInforTemp.MaterialHistoryCards.Add(card);
            //        await _materialInforRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            //    }

            //}

            List<InspectionReport>? listInspectionReport = null;
            if (request.InspectionReports != null)
            {
                if (maintenanceResponse.InspectionReports != null)
                {
                    foreach (InspectionReport inspectionReport in maintenanceResponse.InspectionReports)
                    {
                        InspectionReport existReport = await _inspectionReportRepository.GetById(inspectionReport.InspectionReportId);
                        await _inspectionReportRepository.DeleteAsync(existReport.InspectionReportId);
                    }
                }

                listInspectionReport = new List<InspectionReport>();
                foreach(InspectionReportPut report in request.InspectionReports)
                {
                    var newReportId = Guid.NewGuid().ToString();
                    EPreventiveInspectionStatus reportStatus;
                    Enum.TryParse<EPreventiveInspectionStatus>(report.Status, out reportStatus);

                    var newReport = new InspectionReport(inspectionReportId: newReportId,
                                                         name: report.Name,
                                                         group: report.Group,
                                                         status: reportStatus,
                                                         isRequest: report.IsRequest);

                    _inspectionReportRepository.Update(newReport);
                    await _inspectionReportRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                    listInspectionReport.Add(newReport);
                }
            }

            maintenanceResponse.Update(cause: listCause, 
                                       correction: listCorrection, 
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
                                       images: listImage, 
                                       sounds: listSound,
                                       materials: listMaterial,
                                       code: request.Code,
                                       note: request.Note,
                                       request: null,
                                       maintenanceObject: maintenanceObject,
                                       equipment: equipment,
                                       mold: mold,
                                       dueDate: request.DueDate,
                                       type: type,
                                       inspectionReports: listInspectionReport);

            _maintenanceResponseRepository.Update(maintenanceResponse);

            return await _maintenanceResponseRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
