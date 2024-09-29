using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.JsonMoldAggregate;

namespace WebAPICHATest.Domain.AggregateModels.JsonMoldAggregate
{
    public interface IJsonMoldRepository : IRepository<JsonMold>
    {
        JsonMold Update(JsonArray? request);
    }
}
