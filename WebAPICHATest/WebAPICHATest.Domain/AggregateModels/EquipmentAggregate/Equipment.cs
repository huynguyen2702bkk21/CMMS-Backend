using WebAPICHATest.Domain.AggregateModels.CorrectionAggregate;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.JsonEquipmentAggregate;
using WebAPICHATest.Domain.AggregateModels.PerformanceIndexAggregate;

namespace WebAPICHATest.Domain.AggregateModels.EquipmentAggregate
{
    public class Equipment : Entity, IAggregateRoot
    {
        public enum EEquipmentType
        {
            bigInjection,
            smallInjection,
            mold
        }

        public enum EMaintenanceStatus
        {
            assigned,
            inProgress,
            review,
            completed
        }

        public string? EquipmentId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? ScheduleWorkingTimes { get; set; }
        public EEquipmentType? Type { get; set; }
        public PerformanceIndex? MTBF { get; set; }
        public PerformanceIndex? MTTF { get; set; }
        public PerformanceIndex? OEE { get; set; }
        public decimal UsedTime { get; set; }
        public DateTime UpdatedAt { get; set; }
        public EMaintenanceStatus? Status { get; set; } //Enum
        public List<EquipmentMaterial>? Materials { get; set; }

        private Equipment()
        {

        }

        public Equipment(string? equipmentId)
        {
            EquipmentId = equipmentId;
        }

        public Equipment(string? equipmentId, string? code, string? name, string? scheduleWorkingTimes, EEquipmentType? type, PerformanceIndex? mTBF, PerformanceIndex? mTTF, PerformanceIndex? oEE, DateTime updatedAt, EMaintenanceStatus? status, List<EquipmentMaterial>? material)
        {
            EquipmentId = equipmentId;
            Code = code;
            Name = name;
            ScheduleWorkingTimes = scheduleWorkingTimes;
            Type = type;
            MTBF = mTBF;
            MTTF = mTTF;
            OEE = oEE;
            UpdatedAt = updatedAt;
            Status = EMaintenanceStatus.assigned;
            Materials = material;
        }

        public void Update(string? code, string? name, EEquipmentType? type, DateTime updatedAt, List<EquipmentMaterial>? materials)
        {
            if (code != null)
            {
                Code = code;

            }

            if (name != null)
            {
                Name = name;
            }

            if (type != null)
            {
                Type = type;
            }

            if (materials != null)
            {
                Materials = materials;
            }

            UpdatedAt = updatedAt;
        }

        public static decimal CalculateUsedTimeForEquipment(Equipment? equipment, List<ScheduleEquipmentWorkingTime>? scheduleWorkingTimes, DateTime thisTime)
        {
            decimal totalUsedTime = 0;
            decimal subUsedTime = 0;
            foreach (ScheduleEquipmentWorkingTime equipmentWorkingTime in scheduleWorkingTimes)
            {
                if ((equipmentWorkingTime.from <= thisTime) && (equipmentWorkingTime.to <= thisTime))
                {
                    totalUsedTime += (decimal)TimeSpan.FromTicks((equipmentWorkingTime.to - equipmentWorkingTime.from).Ticks).TotalMinutes;
                }
                else if ((equipmentWorkingTime.from <= thisTime) && (equipmentWorkingTime.to > thisTime))
                {
                    totalUsedTime += (decimal)TimeSpan.FromTicks((thisTime - equipmentWorkingTime.from).Ticks).TotalMinutes;
                }
            }

            for (int i = 0; i < (scheduleWorkingTimes.Count - 1); i++)
            {
                if (equipment.UpdatedAt < scheduleWorkingTimes[0].from)
                {
                    subUsedTime = 0;
                    break;
                }
                if (scheduleWorkingTimes[i].to < equipment.UpdatedAt)
                {
                    subUsedTime += (decimal)TimeSpan.FromTicks((scheduleWorkingTimes[i].to - scheduleWorkingTimes[i].from).Ticks).TotalMinutes;
                }
                else if ((scheduleWorkingTimes[i].from <= equipment.UpdatedAt) && (scheduleWorkingTimes[i].to > equipment.UpdatedAt))
                {
                    subUsedTime += (decimal)TimeSpan.FromTicks((equipment.UpdatedAt - scheduleWorkingTimes[i].from).Ticks).TotalMinutes;
                }
                else if ((scheduleWorkingTimes[i].to <= equipment.UpdatedAt) && (scheduleWorkingTimes[i + 1].from >= equipment.UpdatedAt))
                {
                    subUsedTime += 0;
                    break;
                }
            }

            return (totalUsedTime - subUsedTime);
        }

        public static decimal CalculateReplaceFailure(Equipment equipment, List<MaintenanceResponseWithoutEquipmentMold> recentMaintenanceResponse)
        {
            int numberWorkReplace = 0;
            foreach(MaintenanceResponseWithoutEquipmentMold response in recentMaintenanceResponse)
            {
                foreach(CorrectionWithoutMaintenanceResponse correction in response.Correction)
                {
                    if (correction.CorrectionType == "replace")
                    {
                        numberWorkReplace++;
                    }
                }
            }

            if (numberWorkReplace == 0)
            {
                return equipment.UsedTime;
            }
            else
            {
                return equipment.UsedTime / numberWorkReplace;
            }
        }

        public static decimal CalculateRepairFailure(Equipment equipment, List<MaintenanceResponseWithoutEquipmentMold> recentMaintenanceResponse)
        {
            int numberWorkRepair = 0;
            foreach (MaintenanceResponseWithoutEquipmentMold response in recentMaintenanceResponse)
            {
                foreach (CorrectionWithoutMaintenanceResponse correction in response.Correction)
                {
                    if (correction.CorrectionType == "repair")
                    {
                        numberWorkRepair++;
                    }
                }
            }

            if (numberWorkRepair == 0)
            {
                return equipment.UsedTime;
            }
            else
            {
                return equipment.UsedTime / numberWorkRepair;
            }
        }
    }
}
