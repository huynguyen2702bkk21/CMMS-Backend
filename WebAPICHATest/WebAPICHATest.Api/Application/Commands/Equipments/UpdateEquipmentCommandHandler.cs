using WebAPICHATest.Api.Application.Commands.MaintenanceRequests;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate;
using WebAPICHATest.Domain.AggregateModels.ChartObjAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.PerformanceIndexAggregate;
using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;
using WebAPICHATest.Domain.AggregateModels.WorkingTimeAggregate;
using WebAPICHATest.Domain.AggregateModels.EquipmentAggregate;

namespace WebAPICHATest.Api.Application.Commands.Equipments
{
    public class UpdateEquipmentCommandHandler : IRequestHandler<UpdateEquipmentCommand, bool>
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IEquipmentMaterialRepository _equipmentMaterialRepository;
        private readonly IPerformanceIndexRepository _performanceIndexRepository;
        private readonly IWorkingTimeRepository _workingTimeRepository;

        public UpdateEquipmentCommandHandler(IEquipmentRepository equipmentRepository,
                                             IEquipmentMaterialRepository equipmentMaterialRepository,
                                             IPerformanceIndexRepository performanceIndexRepository,
                                             IWorkingTimeRepository workingTimeRepository)
        {
            _equipmentRepository = equipmentRepository;
            _equipmentMaterialRepository = equipmentMaterialRepository;
            _performanceIndexRepository = performanceIndexRepository;
            _workingTimeRepository = workingTimeRepository;
        }

        public async Task<bool> Handle(UpdateEquipmentCommand request, CancellationToken cancellationToken)
        {
            EEquipmentType type;
            Enum.TryParse<EEquipmentType>(request.Type, out type);

            List<EquipmentMaterial>? listEquipmentMaterial = null;
            if (request.Materials != null)
            {
                listEquipmentMaterial = new List<EquipmentMaterial>();
                foreach (string equipmentMaterialTemp in request.Materials)
                {
                    var equipmentMaterial = await _equipmentMaterialRepository.GetById(equipmentMaterialTemp) ?? throw new NotFoundException();
                    listEquipmentMaterial.Add(equipmentMaterial);
                }
            }

            Equipment? equipment = null;
            equipment = await _equipmentRepository.GetById(request.EquipmentId) ?? throw new NotFoundException();
            equipment.Update(code: request.Code,
                             name: request.Name,
                             type: type,
                             updatedAt: DateTime.UtcNow,
                             materials: listEquipmentMaterial);

            _equipmentRepository.Update(equipment);

            return await _equipmentRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}

