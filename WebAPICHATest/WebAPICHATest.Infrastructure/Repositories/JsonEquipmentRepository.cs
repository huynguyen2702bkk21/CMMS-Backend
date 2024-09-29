using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.JsonEquipmentAggregate;

namespace WebAPICHATest.Infrastructure.Repositories
{
    public class JsonEquipmentRepository : BaseRepository, IJsonEquipmentRepository
    {
        public JsonEquipmentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public JsonEquipment Update(JsonArray? request)
        {
            var newJsonEquipment = new JsonEquipment(request);
            Console.WriteLine(newJsonEquipment.JsonEquipmentString);
            var JsonEquipmentString = newJsonEquipment.JsonEquipmentString;

            var JsonInputArray = JsonEquipmentString.Root.Deserialize<JsonEquipmentInput[]>();
            Console.WriteLine(JsonInputArray.Length);
            foreach(var jsonInput in JsonInputArray)
            {
                Console.WriteLine(jsonInput.code);
                var ScheduleWorkingTimeString = "";
                foreach (ScheduleEquipmentWorkingTime scheduleWorkingTime in jsonInput.workingTimes)
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

            return newJsonEquipment;
        }
    }
}
