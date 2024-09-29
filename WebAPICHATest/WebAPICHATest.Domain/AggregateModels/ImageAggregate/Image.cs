using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;
using WebAPICHATest.Domain.AggregateModels.CauseAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceWorkOrderAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;

namespace WebAPICHATest.Domain.AggregateModels.ImageAggregate
{
    public class Image : Entity, IAggregateRoot
    {
        public string? ImageId { get; set; }
        public string? Value { get; set; }


        private Image()
        {

        }

        public Image(string? imageId, string? value)
        {
            ImageId = imageId;
            Value = value;
        }

        public void Update(string? value)
        {
            Value = value;
        }
    }
}
