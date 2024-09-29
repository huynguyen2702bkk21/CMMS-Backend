using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.JsonMoldAggregate;

namespace WebAPICHATest.Infrastructure.Repositories
{
    public class JsonMoldRepository : BaseRepository, IJsonMoldRepository
    {
        public JsonMoldRepository(ApplicationDbContext context) : base(context)
        {
        }

        public JsonMold Update(JsonArray? request)
        {
            var newJsonMold = new JsonMold(request);
            Console.WriteLine(newJsonMold.JsonMoldString);
            var JsonMoldString = newJsonMold.JsonMoldString;

            var JsonInputArray = JsonMoldString.Root.Deserialize<JsonMoldInput[]>();
            Console.WriteLine(JsonInputArray.Length);
            foreach (var jsonInput in JsonInputArray)
            {
                Console.WriteLine(jsonInput.code);
                var ScheduleWorkingTimeString = "";
                foreach (ScheduleMoldWorkingTime scheduleWorkingTime in jsonInput.workingTimes)
                {
                    //Console.WriteLine($"From:{scheduleWorkingTime.from}");
                    //Console.WriteLine($"To:{scheduleWorkingTime.to}");
                    ScheduleWorkingTimeString += scheduleWorkingTime.from;
                    ScheduleWorkingTimeString += "|";
                    ScheduleWorkingTimeString += scheduleWorkingTime.to;
                    ScheduleWorkingTimeString += "&&";
                }
                Console.WriteLine(ScheduleWorkingTimeString);
            }

            return newJsonMold;
        }
    }
}
