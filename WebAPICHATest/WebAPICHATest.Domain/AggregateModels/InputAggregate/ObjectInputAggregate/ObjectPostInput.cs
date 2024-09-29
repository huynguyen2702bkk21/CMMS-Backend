using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.InputAggregate.DeviceInputAggregate;
using WebAPICHATest.Domain.AggregateModels.InputAggregate.TechnicianInputAggregate;
using WebAPICHATest.Domain.AggregateModels.InputAggregate.WorkInputAggregate;

namespace WebAPICHATest.Domain.AggregateModels.InputAggregate.ObjectInputAggregate
{
    public class ObjectPostInput
    {
        public WorkInputs? works { get; set; }
        public DeviceInputs? devices { get; set; }
        public TechnicianInputs? technicians { get; set; }
        public DateTime firstDateStart { get; set; }

        public ObjectPostInput(WorkInputs? works, DeviceInputs? devices, TechnicianInputs? technicians, DateTime firstDateStart)
        {
            this.works = works;
            this.devices = devices;
            this.technicians = technicians;
            this.firstDateStart = firstDateStart;
        }
    }
}
