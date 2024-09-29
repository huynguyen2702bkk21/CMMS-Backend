using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPICHATest.Domain.AggregateModels.InputAggregate.Common
{
    public class ListJobInforReturn
    {
        public JobInfor[] scheduled { get; set; }
        public JobInfor[] rejected { get; set; }

        public ListJobInforReturn() { } 
        public ListJobInforReturn(JobInfor[] scheduled, JobInfor[] rejected)
        {
            this.scheduled = scheduled;
            this.rejected = rejected;
        }
    }
}
