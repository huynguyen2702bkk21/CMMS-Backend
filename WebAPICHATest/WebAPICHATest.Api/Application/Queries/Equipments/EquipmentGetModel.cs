using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;
using WebAPICHATest.Domain.AggregateModels.ChartObjAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.PerformanceIndexAggregate;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.WorkingTimeAggregate;
using WebAPICHATest.Domain.AggregateModels.JsonEquipmentAggregate;

namespace WebAPICHATest.Api.Application.Queries.Equipments
{
    public class EquipmentGetModel
    {
        public string EquipmentId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public List<ScheduleEquipmentWorkingTime>? ScheduleWorkingTimes { get; set; }
        public string? Type { get; set; }
        public PerformanceIndex? MTBF { get; set; }
        public PerformanceIndex? MTTF { get; set; }
        public PerformanceIndex? OEE { get; set; }
        public string? Status { get; set; } //Enum
        public List<MaintenanceResponseWithoutEquipmentMold>? RecentMaintenanceResponse { get; set; }
        public List<ChartObj>? Errors { get; set; }
        public List<EquipmentMaterial>? Materials { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private EquipmentGetModel() { }

        public EquipmentGetModel(string equipmentId)
        {
            EquipmentId = equipmentId;
        }

        public EquipmentGetModel(string equipmentId, string? code, string? name, List<ScheduleEquipmentWorkingTime>? scheduleWorkingTimes, string? type, PerformanceIndex? mTBF, PerformanceIndex? mTTF, PerformanceIndex? oEE, string? status, List<MaintenanceResponseWithoutEquipmentMold>? recentMaintenanceResponse, List<ChartObj>? errors, List<EquipmentMaterial>? material) : this(equipmentId)
        {
            Code = code;
            Name = name;
            ScheduleWorkingTimes = scheduleWorkingTimes;
            Type = type;
            MTBF = mTBF;
            MTTF = mTTF;
            OEE = oEE;
            Status = status;
            RecentMaintenanceResponse = recentMaintenanceResponse;
            Errors = errors;
            Materials = material;
        }


#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    }
}
