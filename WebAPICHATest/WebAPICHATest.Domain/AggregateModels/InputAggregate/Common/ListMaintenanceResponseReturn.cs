using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;

namespace WebAPICHATest.Domain.AggregateModels.InputAggregate.Common
{
    public class ListMaintenanceResponseReturn
    {
        public List<MaintenanceResponseGetReturn> Scheduled { get; set; }
        public List<MaintenanceResponseGetReturn> Rejected { get; set; }

        public ListMaintenanceResponseReturn()
        {

        }

        public ListMaintenanceResponseReturn(List<MaintenanceResponseGetReturn> scheduled, List<MaintenanceResponseGetReturn> rejected)
        {
            Scheduled = scheduled;
            Rejected = rejected;
        }
    }
}
