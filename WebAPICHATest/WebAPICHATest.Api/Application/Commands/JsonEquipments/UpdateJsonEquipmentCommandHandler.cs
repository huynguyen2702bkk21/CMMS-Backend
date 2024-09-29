using static WebAPICHATest.Domain.AggregateModels.CauseAggregate.Cause;
using WebAPICHATest.Api.Application.Commands.JsonEquipments;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.JsonEquipmentAggregate;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;
using System.Text.Json;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.PerformanceIndexAggregate;

namespace WebAPICHATest.Api.Application.Commands.JsonEquipments
{
    public class UpdateJsonEquipmentCommandHandler : IRequestHandler<UpdateJsonEquipmentCommand, bool>
    {
        private readonly IJsonEquipmentRepository _jsonEquipmentRepository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IEquipmentMaterialRepository _equipmentMaterialRepository;
        private readonly IMaintenanceResponseRepository _maintenanceResponseRepository;
        private readonly IPerformanceIndexRepository _performanceIndexRepository;

        public UpdateJsonEquipmentCommandHandler(IJsonEquipmentRepository jsonEquipmentRepository, 
                                                 IEquipmentRepository equipmentRepository, 
                                                 IEquipmentMaterialRepository equipmentMaterialRepository,
                                                 IMaintenanceResponseRepository maintenanceResponseRepository,
                                                 IPerformanceIndexRepository performanceIndexRepository)
        {
            _jsonEquipmentRepository = jsonEquipmentRepository;
            _equipmentRepository = equipmentRepository;
            _equipmentMaterialRepository = equipmentMaterialRepository;
            _maintenanceResponseRepository = maintenanceResponseRepository;
            _performanceIndexRepository = performanceIndexRepository;
        }

        public async Task<bool> Handle(UpdateJsonEquipmentCommand request, CancellationToken cancellationToken)
        {
            _jsonEquipmentRepository.Update(request.JsonEquipmentString);

            var JsonEquipmentString = request.JsonEquipmentString;
            var JsonInputArray = JsonEquipmentString.Root.Deserialize<JsonEquipmentInput[]>();

            //DateTime today =
            //("27/04/2023 09:30", "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            DateTime today = DateTime.UtcNow;
            foreach (var jsonInput in JsonInputArray)
            {
                var equipment = await _equipmentRepository.GetByCode(jsonInput.code) ?? throw new NotFoundException();
                var ScheduleWorkingTimeString = JsonEquipmentInput.FromObjectToString(jsonInput.workingTimes);
                equipment.ScheduleWorkingTimes = ScheduleWorkingTimeString;


                List<ScheduleEquipmentWorkingTime>? scheduleWorkingTimes = null;
                if (equipment.ScheduleWorkingTimes != null)
                {
                    scheduleWorkingTimes = JsonEquipmentInput.ConvertStringToObject(equipment.ScheduleWorkingTimes);
                }

                if (scheduleWorkingTimes != null)
                {
                    var getEquipment = await _equipmentRepository.GetById(equipment.EquipmentId) ?? throw new NotFoundException();
                    getEquipment.UsedTime += Equipment.CalculateUsedTimeForEquipment(equipment, scheduleWorkingTimes, today);
                    getEquipment.UpdatedAt = today;
                    var listMaintenanceResponse = await _maintenanceResponseRepository.GetListByEquipmentId(equipment.EquipmentId);

                    var MTBF = await _performanceIndexRepository.GetById(getEquipment.MTBF.PerformanceIndexId) ?? throw new NotFoundException();
                    MTBF.RecentValue = Equipment.CalculateRepairFailure(getEquipment, listMaintenanceResponse);
                    _performanceIndexRepository.Update(MTBF);
                    await _performanceIndexRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

                    var MTTF = await _performanceIndexRepository.GetById(getEquipment.MTTF.PerformanceIndexId) ?? throw new NotFoundException();
                    MTTF.RecentValue = Equipment.CalculateReplaceFailure(getEquipment, listMaintenanceResponse);
                    _performanceIndexRepository.Update(MTTF);
                    await _performanceIndexRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

                    _equipmentRepository.Update(getEquipment);
                    await _equipmentRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                }

                if (equipment.Materials != null && scheduleWorkingTimes != null)
                {
                    var listEquipmentMaterial = new List<EquipmentMaterial>();
                    foreach (EquipmentMaterial equipmentMaterialTemp in equipment.Materials)
                    {
                        var equipmentMaterial = await _equipmentMaterialRepository.GetById(equipmentMaterialTemp.EquipmentMaterialId) ?? throw new NotFoundException();
                        equipmentMaterial.UsedTime += EquipmentMaterial.CalculateUsedTimeForEquipmentMaterial(equipmentMaterialTemp, scheduleWorkingTimes, today);
                        equipmentMaterial.UpdatedAt = today;
                        _equipmentMaterialRepository.Update(equipmentMaterial);
                        await _equipmentMaterialRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                    }
                }
            }

            return await _jsonEquipmentRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
