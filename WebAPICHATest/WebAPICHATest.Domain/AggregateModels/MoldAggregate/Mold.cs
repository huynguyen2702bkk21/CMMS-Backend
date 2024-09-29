using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Domain.AggregateModels.ProductAggregate;
using WebAPICHATest.Domain.AggregateModels.StandardAggregate;
using static WebAPICHATest.Domain.AggregateModels.MoldAggregate.Mold;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.ChartObjAggregate;
using WebAPICHATest.Domain.AggregateModels.PerformanceIndexAggregate;
using WebAPICHATest.Domain.AggregateModels.CorrectionAggregate;
using WebAPICHATest.Domain.AggregateModels.MoldAggregate;
using WebAPICHATest.Domain.AggregateModels.JsonEquipmentAggregate;
using WebAPICHATest.Domain.AggregateModels.JsonMoldAggregate;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.EquipmentAggregate;

namespace WebAPICHATest.Domain.AggregateModels.MoldAggregate
{
    public class Mold : Entity, IAggregateRoot
    {
        public string? MoldId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; } 
        public int? Cavity { get; set; }
        public List<Product>? Products { get; set; }
        public string? DocumentLink { get; set; }
        public string? Images { get; set; }
        public List<Standard>? Standards { get; set; }
        public PerformanceIndex? MTBF { get; set; }
        public PerformanceIndex? MTTF { get; set; }
        public PerformanceIndex? OEE { get; set; }
        public decimal UsedTime { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? ScheduleWorkingTimes { get; set; }
        public EMaintenanceObjectStatus? Status { get; set; }
        public List<EquipmentMaterial>? Materials { get; set; }

        private Mold()
        {

        }

        public Mold(string? moldId)
        {
            MoldId = moldId;
        }

        public Mold(string? moldId, string? code, string? name, int? cavity, List<Product>? products, string? documentLink, string? images, List<Standard>? standards, PerformanceIndex? mTBF, PerformanceIndex? mTTF, PerformanceIndex? oEE, decimal usedTime, DateTime updatedAt, string? scheduleWorkingTimes, EMaintenanceObjectStatus? status, List<EquipmentMaterial>? materials)
        {
            MoldId = moldId;
            Code = code;
            Name = name;
            Cavity = cavity;
            Products = products;
            DocumentLink = documentLink;
            Images = images;
            Standards = standards;
            MTBF = mTBF;
            MTTF = mTTF;
            OEE = oEE;
            UsedTime = usedTime;
            UpdatedAt = updatedAt;
            ScheduleWorkingTimes = scheduleWorkingTimes;
            Status = status;
            Materials = materials;
        }

        public void Update(string? code, string? name, int? cavity, List<Product>? products, string? documentLink, string? images, List<Standard>? standards, DateTime updatedAt, EMaintenanceObjectStatus? status, List<EquipmentMaterial>? materials)
        {
            if (code != null)
            {
                Code = code;
            }

            if (name != null)
            {
                Name = name;

            }

            if (cavity != null)
            {
                Cavity = cavity;

            }

            if (products != null)
            {
                Products = products;
            }

            if (documentLink != null)
            {
                DocumentLink = documentLink;
            }
            
            if (images != null)
            {
                Images = images;

            }

            if (standards != null)
            {
                Standards = standards;

            }

            if (status != null)
            {
                Status = status;
            }

            if (materials != null)
            {
                Materials = materials;
            }

            UpdatedAt = updatedAt;
        }

        public enum EMaintenanceObjectStatus
        {
            underMaintenance,
            working,
            idle
        }

        public static decimal CalculateUsedTimeForMold(Mold? mold, List<ScheduleMoldWorkingTime>? scheduleWorkingTimes, DateTime thisTime)
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
                if (mold.UpdatedAt < scheduleWorkingTimes[0].from)
                {
                    subUsedTime = 0;
                    break;
                }
                if (scheduleWorkingTimes[i].to < mold.UpdatedAt)
                {
                    subUsedTime += (decimal)TimeSpan.FromTicks((scheduleWorkingTimes[i].to - scheduleWorkingTimes[i].from).Ticks).TotalMinutes;
                }
                else if ((scheduleWorkingTimes[i].from <= mold.UpdatedAt) && (scheduleWorkingTimes[i].to > mold.UpdatedAt))
                {
                    subUsedTime += (decimal)TimeSpan.FromTicks((mold.UpdatedAt - scheduleWorkingTimes[i].from).Ticks).TotalMinutes;
                }
                else if ((scheduleWorkingTimes[i].to <= mold.UpdatedAt) && (scheduleWorkingTimes[i + 1].from >= mold.UpdatedAt))
                {
                    subUsedTime += 0;
                    break;
                }
            }

            return (totalUsedTime - subUsedTime);
        }

        public static decimal CalculateReplaceFailure(Mold mold, List<MaintenanceResponseWithoutEquipmentMold> recentMaintenanceResponse)
        {
            int numberWorkReplace = 0;
            foreach (MaintenanceResponseWithoutEquipmentMold response in recentMaintenanceResponse)
            {
                foreach (CorrectionWithoutMaintenanceResponse correction in response.Correction)
                {
                    if (correction.CorrectionType == "replace")
                    {
                        numberWorkReplace++;
                    }
                }
            }

            if (numberWorkReplace == 0)
            {
                return mold.UsedTime;
            }
            else
            {
                return mold.UsedTime / numberWorkReplace;
            }
        }

        public static decimal CalculateRepairFailure(Mold mold, List<MaintenanceResponseWithoutEquipmentMold> recentMaintenanceResponse)
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
                return mold.UsedTime;
            }
            else
            {
                return mold.UsedTime / numberWorkRepair;
            }
        }
    }
}
