using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.JsonEquipmentAggregate;
using WebAPICHATest.Domain.AggregateModels.JsonMoldAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;

namespace WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate
{
    public class EquipmentMaterial : Entity, IAggregateRoot
    {
        public string? EquipmentMaterialId { get; set; }
        public MaterialInfor? MaterialInfor { get; set; }
        public decimal? FullTime { get; set; }
        public decimal? UsedTime { get; set; }
        public DateTime InstalledTime { get; set; }
        public DateTime UpdatedAt { get; set; }
        public EquipmentMaterial(string? equipmentMaterialId)
        {
            EquipmentMaterialId = equipmentMaterialId;
        }

        private EquipmentMaterial()
        {

        }

        public EquipmentMaterial(string? equipmentMaterialId, MaterialInfor? materialInfor, decimal? fullTime, decimal? usedTime, DateTime installedTime, DateTime updateAt)
        {
            EquipmentMaterialId = equipmentMaterialId;
            MaterialInfor = materialInfor;
            FullTime = fullTime;
            UsedTime = usedTime;
            InstalledTime = installedTime;
            UpdatedAt = updateAt;
        }

        public void Update(MaterialInfor? materialInfor, decimal? fullTime, decimal? usedTime, DateTime installedTime, DateTime updateAt)
        {
            if (materialInfor != null)
            {
                MaterialInfor = materialInfor;

            }

            if(fullTime!= null)
            {
                FullTime = fullTime;
            }

            if(usedTime!= null)
            {
                UsedTime = usedTime;
            }

            InstalledTime = installedTime;
            UpdatedAt = updateAt;
        }

        public static decimal CalculateUsedTimeForEquipmentMaterial(EquipmentMaterial equipmentMaterial, List<ScheduleEquipmentWorkingTime>? scheduleWorkingTimes, DateTime thisTime)
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
                if (equipmentMaterial.UpdatedAt < scheduleWorkingTimes[0].from)
                {
                    subUsedTime = 0;
                    break;
                }
                if (scheduleWorkingTimes[i].to < equipmentMaterial.UpdatedAt)
                {
                    subUsedTime += (decimal)TimeSpan.FromTicks((scheduleWorkingTimes[i].to - scheduleWorkingTimes[i].from).Ticks).TotalMinutes;
                }
                else if ((scheduleWorkingTimes[i].from <= equipmentMaterial.UpdatedAt) && (scheduleWorkingTimes[i].to > equipmentMaterial.UpdatedAt))
                {
                    subUsedTime += (decimal)TimeSpan.FromTicks((equipmentMaterial.UpdatedAt - scheduleWorkingTimes[i].from).Ticks).TotalMinutes;
                }
                else if ((scheduleWorkingTimes[i].to <= equipmentMaterial.UpdatedAt) && (scheduleWorkingTimes[i + 1].from >= equipmentMaterial.UpdatedAt))
                {
                    subUsedTime += 0;
                    break;
                }
            }

            return (totalUsedTime - subUsedTime);
        }

        public static decimal CalculateUsedTimeForMoldMaterial(EquipmentMaterial equipmentMaterial, List<ScheduleMoldWorkingTime>? scheduleWorkingTimes, DateTime thisTime)
        {
            decimal totalUsedTime = 0;
            decimal subUsedTime = 0;
            foreach (ScheduleMoldWorkingTime moldWorkingTime in scheduleWorkingTimes)
            {
                if ((moldWorkingTime.from <= thisTime) && (moldWorkingTime.to <= thisTime))
                {
                    totalUsedTime += (decimal)TimeSpan.FromTicks((moldWorkingTime.to - moldWorkingTime.from).Ticks).TotalMinutes;
                }
                else if ((moldWorkingTime.from <= thisTime) && (moldWorkingTime.to > thisTime))
                {
                    totalUsedTime += (decimal)TimeSpan.FromTicks((thisTime - moldWorkingTime.from).Ticks).TotalMinutes;
                }
            }

            for (int i = 0; i < (scheduleWorkingTimes.Count - 1); i++)
            {
                if (equipmentMaterial.UpdatedAt < scheduleWorkingTimes[0].from)
                {
                    subUsedTime = 0;
                    break;
                }
                if (scheduleWorkingTimes[i].to < equipmentMaterial.UpdatedAt)
                {
                    subUsedTime += (decimal)TimeSpan.FromTicks((scheduleWorkingTimes[i].to - scheduleWorkingTimes[i].from).Ticks).TotalMinutes;
                }
                else if ((scheduleWorkingTimes[i].from <= equipmentMaterial.UpdatedAt) && (scheduleWorkingTimes[i].to > equipmentMaterial.UpdatedAt))
                {
                    subUsedTime += (decimal)TimeSpan.FromTicks((equipmentMaterial.UpdatedAt - scheduleWorkingTimes[i].from).Ticks).TotalMinutes;
                }
                else if ((scheduleWorkingTimes[i].to <= equipmentMaterial.UpdatedAt) && (scheduleWorkingTimes[i + 1].from >= equipmentMaterial.UpdatedAt))
                {
                    subUsedTime += 0;
                    break;
                }
            }

            return (totalUsedTime - subUsedTime);
        }
    }
}
