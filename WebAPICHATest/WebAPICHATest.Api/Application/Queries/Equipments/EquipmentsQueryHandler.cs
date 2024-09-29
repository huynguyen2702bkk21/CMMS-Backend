using Microsoft.VisualBasic;
using System.Globalization;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Api.Application.Queries.MaintenanceRequests;
using WebAPICHATest.Domain.AggregateModels.CauseAggregate;
using WebAPICHATest.Domain.AggregateModels.ChartObjAggregate;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.JsonEquipmentAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;
using WebAPICHATest.Domain.AggregateModels.PerformanceIndexAggregate;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
using WebAPICHATest.Domain.AggregateModels.WorkingTimeAggregate;
using WebAPICHATest.Domain.ConstantDomain;
using WebAPICHATest.Infrastructure;
using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;

namespace WebAPICHATest.Api.Application.Queries.Equipments
{
    public class EquipmentsQueryHandler : IRequestHandler<EquipmentsQuery, List<EquipmentViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMaintenanceResponseRepository _maintenanceResponseRepository;
        private readonly ICauseRepository _causeRepository;
        private readonly IEquipmentMaterialRepository _equipmentMaterialRepository;
        private readonly IMaterialInforRepository _materialInforRepository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IPerformanceIndexRepository _performanceIndexRepository;

        public EquipmentsQueryHandler(ApplicationDbContext context, IMapper mapper, 
                                      IMaintenanceResponseRepository maintenanceResponseRepository, 
                                      ICauseRepository causeRepository,
                                      IEquipmentMaterialRepository equipmentMaterialRepository,
                                      IMaterialInforRepository materialInforRepository,
                                      IEquipmentRepository equipmentRepository,
                                      IPerformanceIndexRepository performanceIndexRepository)
        {
            _context = context;
            _mapper = mapper;
            _maintenanceResponseRepository = maintenanceResponseRepository;
            _causeRepository = causeRepository;
            _equipmentMaterialRepository = equipmentMaterialRepository;
            _materialInforRepository = materialInforRepository;
            _equipmentRepository = equipmentRepository;
            _performanceIndexRepository = performanceIndexRepository;
        }

        public async Task<List<EquipmentViewModel>> Handle(EquipmentsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Equipments
                .Include(x => x.MTBF)
                .ThenInclude(x => x.History)
                .Include(x => x.MTTF)
                .ThenInclude(x => x.History)
                .Include(x => x.OEE)
                .ThenInclude(x => x.History)
                .Include(x => x.Materials)
                .ThenInclude(x => x.MaterialInfor)
                .AsNoTracking().ToListAsync();

            //DateTime today = DateTime.ParseExact("27/04/2023 09:30", "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            DateTime today = DateTime.UtcNow;
            foreach (var equipment in result)
            {
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

            var listEquipmentGet = new List<EquipmentGetModel>();
            foreach (var equipment in result)
            {
                var equipmentGet = new EquipmentGetModel(equipment.EquipmentId);
                equipmentGet.Code = equipment.Code;
                equipmentGet.Name = equipment.Name;

                if (equipment.ScheduleWorkingTimes != null)
                {
                    List<ScheduleEquipmentWorkingTime>? scheduleWorkingTimes = JsonEquipmentInput.ConvertStringToObject(equipment.ScheduleWorkingTimes);
                    equipmentGet.ScheduleWorkingTimes = scheduleWorkingTimes;
                }

                equipmentGet.Type = Enum.GetName(typeof(EEquipmentType), equipment.Type);
                equipmentGet.MTBF = equipment.MTBF;
                equipmentGet.MTTF = equipment.MTTF;
                equipmentGet.OEE = equipment.OEE;
                equipmentGet.Status = Enum.GetName(typeof(EMaintenanceStatus), equipment.Status);
                var listMaintenanceResponse = await _maintenanceResponseRepository.GetListByEquipmentId(equipment.EquipmentId);

                foreach(MaintenanceResponseWithoutEquipmentMold mres in listMaintenanceResponse)
                {
                    Console.WriteLine($"The mres {mres.Code} has list cause with the length: {mres.Cause.Count}");
                }
                equipmentGet.RecentMaintenanceResponse = listMaintenanceResponse;
                equipmentGet.Errors = _maintenanceResponseRepository.ConvertFromCauseToChartObj(listMaintenanceResponse);
                equipmentGet.Materials = equipment.Materials;

                listEquipmentGet.Add(equipmentGet);
            }

            return _mapper.Map<List<EquipmentGetModel>, List<EquipmentViewModel>>(listEquipmentGet);
        }
    }
}
