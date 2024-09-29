using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.JsonPersonAggregate;

namespace WebAPICHATest.Infrastructure.Repositories
{
    public class JsonPersonRepository : BaseRepository, IJsonPersonRepository
    {
        public JsonPersonRepository(ApplicationDbContext context) : base(context)
        {
        }

        public JsonPerson Update(JsonArray? request)
        {
            var newJsonPerson = new JsonPerson(request);
            Console.WriteLine(newJsonPerson.JsonPersonString);
            var JsonPersonString = newJsonPerson.JsonPersonString;

            var JsonInputArray = JsonPersonString.Root.Deserialize<JsonPersonInput[]>();
            Console.WriteLine(JsonInputArray.Length);
            foreach (var jsonInput in JsonInputArray)
            {
                Console.WriteLine(jsonInput.id);
                var ScheduleWorkingTimeString = "";
                foreach (SchedulePersonWorkingTime[] scheduleWorkingTime in jsonInput.workingTime)
                {
                    foreach(SchedulePersonWorkingTime time in scheduleWorkingTime)
                    {
                        ScheduleWorkingTimeString += time.from;
                        ScheduleWorkingTimeString += "|";
                        ScheduleWorkingTimeString += time.to;
                        ScheduleWorkingTimeString += "&&";
                    }
                }
                Console.WriteLine(ScheduleWorkingTimeString);
            }

            return newJsonPerson;
        }
    }
}
