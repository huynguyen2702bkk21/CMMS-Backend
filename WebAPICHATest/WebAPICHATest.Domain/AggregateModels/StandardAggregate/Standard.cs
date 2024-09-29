using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Domain.AggregateModels.KitTestAggregate;

namespace WebAPICHATest.Domain.AggregateModels.StandardAggregate
{
    public class Standard : Entity, IAggregateRoot
    {
        public string? StandardId { get; set; }
        public string? Images { get; set; }
        public string? Measurements { get; set; }
        public KitTest? KitTest { get; set; } 

        private Standard()
        {

        }

        public Standard(string? standardId, string? images, string? measurements, KitTest? kitTest)
        {
            StandardId = standardId;
            Images = images;
            Measurements = measurements;
            KitTest = kitTest;
        }

        public void Update(string? images, string? measurements, KitTest? kitTest)
        {
            Images = images;
            Measurements = measurements;
            KitTest = kitTest;
        }
    }
}
