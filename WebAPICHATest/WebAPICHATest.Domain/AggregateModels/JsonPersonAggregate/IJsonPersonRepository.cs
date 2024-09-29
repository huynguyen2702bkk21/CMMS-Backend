using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.JsonPersonAggregate;

namespace WebAPICHATest.Domain.AggregateModels.JsonPersonAggregate
{
    public interface IJsonPersonRepository : IRepository<JsonPerson>
    {
        JsonPerson Update(JsonArray? request);
    }
}
