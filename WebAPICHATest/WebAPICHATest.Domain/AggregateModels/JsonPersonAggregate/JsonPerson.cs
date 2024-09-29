using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace WebAPICHATest.Domain.AggregateModels.JsonPersonAggregate
{
    public class JsonPerson : Entity, IAggregateRoot
    {
        public JsonArray? JsonPersonString { get; set; }


        private JsonPerson()
        {

        }

        public JsonPerson(JsonArray? jsonPersonString)
        {
            JsonPersonString = jsonPersonString;
        }
    }
}
