using Microsoft.VisualBasic;
using WebAPICHATest.Domain.AggregateModels.InputAggregate.WareHouseMaterialInputAggregate;

namespace WebAPICHATest.Domain.AggregateModels.InputAggregate.Common
{
    public class JobInfor
    {
        public int id { get; set; }
        public int priority { get; set; }
        public string device { get; set; }
        public string work { get; set; }
        public string technician { get; set; }
        public DateTime dueDate { get; set; }
        public DateTime startPlannedDate { get; set; }
        public DateTime endPlannedDate { get; set; }
        public int estProcessTime { get; set; }
        public MaterialOnWork[]? materials { get; set; }
        public int[] arrayFail { get; set; } = new int[5];
        public string? ReasonFail { get; set; }
        public JobInfor() { }

        public JobInfor(int id, string device, string work, string technician, DateTime startPlannedDate, DateTime endPlannedDate)
        {
            this.id = id;
            this.device = device;
            this.work = work;
            this.technician = technician;
            this.startPlannedDate = startPlannedDate;
            this.endPlannedDate = endPlannedDate;
        }

        public JobInfor(int id, int priority, string device, string work, string technician, DateTime dueDate, DateTime startPlannedDate, DateTime endPlannedDate, int estProcessTime, MaterialOnWork[]? materials, int[] arrayFail, string? reasonFail)
        {
            this.id = id;
            this.priority = priority;
            this.device = device;
            this.work = work;
            this.technician = technician;
            this.dueDate = dueDate;
            this.startPlannedDate = startPlannedDate;
            this.endPlannedDate = endPlannedDate;
            this.estProcessTime = estProcessTime;
            this.materials = materials;
            this.arrayFail = arrayFail;
            ReasonFail = reasonFail;
        }
    }
}
