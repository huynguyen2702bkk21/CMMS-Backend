using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace WebAPICHATest.Domain.AggregateModels.JsonEquipmentAggregate
{
    public class JsonEquipment : Entity, IAggregateRoot
    {
        public JsonArray? JsonEquipmentString { get; set; }


        private JsonEquipment()
        {

        }

        public JsonEquipment(JsonArray? jsonEquipmentString)
        {
            JsonEquipmentString = jsonEquipmentString;
        }
    }
}
