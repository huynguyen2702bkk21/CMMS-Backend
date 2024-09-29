using System.Text.Json;
using WebAPICHATest.Api.Application.Commands.JsonMolds;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.JsonMoldAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.MoldAggregate;
using WebAPICHATest.Domain.AggregateModels.PerformanceIndexAggregate;

namespace WebAPICHATest.Api.Application.Commands.JsonMolds
{
    public class UpdateJsonMoldCommandHandler : IRequestHandler<UpdateJsonMoldCommand, bool>
    {
        private readonly IJsonMoldRepository _jsonMoldRepository;
        private readonly IMoldRepository _moldRepository;
        private readonly IEquipmentMaterialRepository _equipmentMaterialRepository;
        private readonly IMaintenanceResponseRepository _maintenanceResponseRepository;
        private readonly IPerformanceIndexRepository _performanceIndexRepository;

        public UpdateJsonMoldCommandHandler(IJsonMoldRepository jsonMoldRepository,
                                                 IMoldRepository equipmentRepository,
                                                 IEquipmentMaterialRepository equipmentMaterialRepository,
                                                 IMaintenanceResponseRepository maintenanceResponseRepository,
                                                 IPerformanceIndexRepository performanceIndexRepository)
        {
            _jsonMoldRepository = jsonMoldRepository;
            _moldRepository = equipmentRepository;
            _equipmentMaterialRepository = equipmentMaterialRepository;
            _maintenanceResponseRepository = maintenanceResponseRepository;
            _performanceIndexRepository = performanceIndexRepository;
        }

        public async Task<bool> Handle(UpdateJsonMoldCommand request, CancellationToken cancellationToken)
        {
            _jsonMoldRepository.Update(request.JsonMoldString);

            var JsonMoldString = request.JsonMoldString;
            var JsonInputArray = JsonMoldString.Root.Deserialize<JsonMoldInput[]>();

            //DateTime today = DateTime.ParseExact("27/04/2023 09:30", "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            DateTime today = DateTime.UtcNow;
            foreach (var jsonInput in JsonInputArray)
            {
                var mold = await _moldRepository.GetByCode(jsonInput.code) ?? throw new NotFoundException();
                var ScheduleWorkingTimeString = JsonMoldInput.FromObjectToString(jsonInput.workingTimes);
                mold.ScheduleWorkingTimes = ScheduleWorkingTimeString;


                List<ScheduleMoldWorkingTime>? scheduleWorkingTimes = null;
                if (mold.ScheduleWorkingTimes != null)
                {
                    scheduleWorkingTimes = JsonMoldInput.ConvertStringToObject(mold.ScheduleWorkingTimes);
                }

                if (scheduleWorkingTimes != null)
                {
                    var getMold = await _moldRepository.GetById(mold.MoldId) ?? throw new NotFoundException();
                    getMold.UsedTime += Mold.CalculateUsedTimeForMold(mold, scheduleWorkingTimes, today);
                    getMold.UpdatedAt = today;
                    var listMaintenanceResponse = await _maintenanceResponseRepository.GetListByMoldId(mold.MoldId);

                    var MTBF = await _performanceIndexRepository.GetById(getMold.MTBF.PerformanceIndexId) ?? throw new NotFoundException();
                    MTBF.RecentValue = Mold.CalculateRepairFailure(getMold, listMaintenanceResponse);
                    _performanceIndexRepository.Update(MTBF);
                    await _performanceIndexRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

                    var MTTF = await _performanceIndexRepository.GetById(getMold.MTTF.PerformanceIndexId) ?? throw new NotFoundException();
                    MTTF.RecentValue = Mold.CalculateReplaceFailure(getMold, listMaintenanceResponse);
                    _performanceIndexRepository.Update(MTTF);
                    await _performanceIndexRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

                    _moldRepository.Update(getMold);
                    await _moldRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                }

                if (mold.Materials != null && scheduleWorkingTimes != null)
                {
                    var listMoldMaterial = new List<EquipmentMaterial>();
                    foreach (EquipmentMaterial equipmentMaterialTemp in mold.Materials)
                    {
                        var equipmentMaterial = await _equipmentMaterialRepository.GetById(equipmentMaterialTemp.EquipmentMaterialId) ?? throw new NotFoundException();
                        equipmentMaterial.UsedTime += EquipmentMaterial.CalculateUsedTimeForMoldMaterial(equipmentMaterialTemp, scheduleWorkingTimes, today);
                        equipmentMaterial.UpdatedAt = today;
                        _equipmentMaterialRepository.Update(equipmentMaterial);
                        await _equipmentMaterialRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                    }
                }
            }

            return await _jsonMoldRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
