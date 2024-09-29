using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPICHATest.Domain.AggregateModels.JsonMoldAggregate
{
    public class FromJsonToMold
    {
        public JsonMoldInput[] JsonInput { get; set; }
    }

    public class JsonMoldInput
    {
        public string code { get; set; }
        public ScheduleMoldWorkingTime[] workingTimes { get; set; }

        public static string? FromObjectToString(ScheduleMoldWorkingTime[]? request)
        {
            var ScheduleWorkingTimeString = "";
            foreach (ScheduleMoldWorkingTime scheduleWorkingTime in request)
            {
                ScheduleWorkingTimeString += scheduleWorkingTime.from.ToString("dd/MM/yyyy HH:mm");
                ScheduleWorkingTimeString += "|";
                ScheduleWorkingTimeString += scheduleWorkingTime.to.ToString("dd/MM/yyyy HH:mm");
                ScheduleWorkingTimeString += "&&";
            }

            return ScheduleWorkingTimeString;
        }

        public static List<ScheduleMoldWorkingTime>? ConvertStringToObject(string? request)
        {
            if (request != null)
            {
                string[] ScheduleWorkingTimeList = request?.Split("&&");
                List<ScheduleMoldWorkingTime> ScheduleWorkingTimes = new List<ScheduleMoldWorkingTime>();
                foreach (string item in ScheduleWorkingTimeList)
                {
                    if (item != "")
                    {
                        var newScheduleWorkingTime = new ScheduleMoldWorkingTime();
                        string? fromString = item.Split('|')[0];
                        newScheduleWorkingTime.from = DateTime.ParseExact(fromString, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                        string? toString = item.Split('|')[1];
                        newScheduleWorkingTime.to = DateTime.ParseExact(toString, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                        ScheduleWorkingTimes.Add(newScheduleWorkingTime);
                    }
                }
                return ScheduleWorkingTimes;
            }

            return new List<ScheduleMoldWorkingTime>();

        }
    }

    public class ScheduleMoldWorkingTime
    {
        public DateTime from { get; set; }
        public DateTime to { get; set; }
    }
}
