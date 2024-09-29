using static WebAPICHATest.Domain.AggregateModels.MoldAggregate.Mold;
using WebAPICHATest.Domain.AggregateModels.ChartObjAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.ProductAggregate;
using WebAPICHATest.Domain.AggregateModels.StandardAggregate;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Domain.AggregateModels.PerformanceIndexAggregate;
using WebAPICHATest.Domain.AggregateModels.JsonEquipmentAggregate;

namespace WebAPICHATest.Api.Application.Queries.Molds
{
    public class MoldGetModel
    {
        public string MoldId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public int? Cavity { get; set; }
        public List<Product>? Products { get; set; }
        public string? DocumentLink { get; set; }
        public List<string>? Images { get; set; }
        public List<Standard>? Standards { get; set; }
        public PerformanceIndex? MTBF { get; set; }
        public PerformanceIndex? MTTF { get; set; }
        public PerformanceIndex? OEE { get; set; }
        public List<ScheduleEquipmentWorkingTime>? ScheduleWorkingTimes { get; set; }
        public string? Status { get; set; }
        public List<MaintenanceResponseWithoutEquipmentMold>? RecentMaintenanceResponses { get; set; }
        public List<ChartObj>? Errors { get; set; }
        public List<EquipmentMaterial>? Materials { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private MoldGetModel() { }

        public MoldGetModel(string moldId)
        {
            MoldId = moldId;
        }

        public MoldGetModel(string moldId, string? code, string? name, int? cavity, List<Product>? products, string? documentLink, List<string>? images, List<Standard>? standards, PerformanceIndex? mTBF, PerformanceIndex? mTTF, PerformanceIndex? oEE, List<ScheduleEquipmentWorkingTime>? scheduleWorkingTimes, string? status, List<MaintenanceResponseWithoutEquipmentMold>? recentMaintenanceResponses, List<ChartObj>? errors, List<EquipmentMaterial>? materials) : this(moldId)
        {
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
            ScheduleWorkingTimes = scheduleWorkingTimes;
            Status = status;
            RecentMaintenanceResponses = recentMaintenanceResponses;
            Errors = errors;
            Materials = materials;
        }




#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
