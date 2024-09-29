using static WebAPICHATest.Domain.AggregateModels.KitTestAggregate.KitTest;
using WebAPICHATest.Domain.AggregateModels.ChartObjAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;

namespace WebAPICHATest.Api.Application.Queries.KitTests
{
    public class KitTestViewModel
    {
        public string KitTestId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
       
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private KitTestViewModel() { }

        public KitTestViewModel(string kitTestId, string code, string name)
        {
            KitTestId = kitTestId;
            Code = code;
            Name = name;
        }


#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    }
}
