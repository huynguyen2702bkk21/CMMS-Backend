using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPICHATest.Domain.AggregateModels.JsonPersonAggregate
{
    public class FromJsonToPerson
    {
        public JsonPersonInput[] JsonInput { get; set; }
    }

    public class JsonPersonInput
    {
        public string id { get; set; }
        public string name { get; set; }
        public SchedulePersonWorkingTime[][] workingTime { get; set; }

        public static string? FromObjectToString(SchedulePersonWorkingTime[][]? request)
        {
            var ScheduleWorkingTimeString = "";
            foreach (SchedulePersonWorkingTime[] scheduleWorkingTime in request)
            {
                foreach (SchedulePersonWorkingTime time in scheduleWorkingTime)
                {
                    ScheduleWorkingTimeString += time.from.ToString("dd/MM/yyyy HH:mm");
                    ScheduleWorkingTimeString += "|";
                    ScheduleWorkingTimeString += time.to.ToString("dd/MM/yyyy HH:mm");
                    ScheduleWorkingTimeString += "&&";
                }
            }

            return ScheduleWorkingTimeString;
        }

        public static List<SchedulePersonWorkingTime>? ConvertStringToObject(string? request)
        {
            string[] ScheduleWorkingTimeList = request.Split("&&");
            List<SchedulePersonWorkingTime> ScheduleWorkingTimes = new List<SchedulePersonWorkingTime>();
            foreach (string item in ScheduleWorkingTimeList)
            {
                if (item != "")
                {
                    var newScheduleWorkingTime = new SchedulePersonWorkingTime();
                    string? fromString = item.Split('|')[0];
                    newScheduleWorkingTime.from = DateTime.ParseExact(fromString, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                    string? toString = item.Split('|')[1];
                    newScheduleWorkingTime.to = DateTime.ParseExact(toString, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                    ScheduleWorkingTimes.Add(newScheduleWorkingTime);
                }
            }

            return ScheduleWorkingTimes;
        }
    }

    public class SchedulePersonWorkingTime
    {
        public DateTime from { get; set; }
        public DateTime to { get; set; }
    }
}
