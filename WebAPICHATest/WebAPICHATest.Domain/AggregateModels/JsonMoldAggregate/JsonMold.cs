using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace WebAPICHATest.Domain.AggregateModels.JsonMoldAggregate
{
    public class JsonMold : Entity, IAggregateRoot
    {
        public JsonArray? JsonMoldString { get; set; }


        private JsonMold()
        {

        }

        public JsonMold(JsonArray? jsonMoldString)
        {
            JsonMoldString = jsonMoldString;
        }
    }
}
