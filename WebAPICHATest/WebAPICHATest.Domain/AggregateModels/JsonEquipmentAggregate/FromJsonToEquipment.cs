using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPICHATest.Domain.AggregateModels.JsonEquipmentAggregate
{

    public class FromJsonToEquipment
    {
        public JsonEquipmentInput[] JsonInput { get; set; }
    }

    public class JsonEquipmentInput
    {
        public string code { get; set; }
        public ScheduleEquipmentWorkingTime[] workingTimes { get; set; }

        public static string? FromObjectToString(ScheduleEquipmentWorkingTime[]? request)
        {
            var ScheduleWorkingTimeString = "";
            foreach (ScheduleEquipmentWorkingTime scheduleWorkingTime in request)
            {
                ScheduleWorkingTimeString += scheduleWorkingTime.from.ToString("dd/MM/yyyy HH:mm");
                ScheduleWorkingTimeString += "|";
                ScheduleWorkingTimeString += scheduleWorkingTime.to.ToString("dd/MM/yyyy HH:mm");
                ScheduleWorkingTimeString += "&&";
            }

            return ScheduleWorkingTimeString;
        }

        public static List<ScheduleEquipmentWorkingTime>? ConvertStringToObject(string? request)
        {
            if (request != null)
            {
                string[] ScheduleWorkingTimeList = request?.Split("&&");
                List<ScheduleEquipmentWorkingTime> ScheduleWorkingTimes = new List<ScheduleEquipmentWorkingTime>();
                foreach (string item in ScheduleWorkingTimeList)
                {
                    if (item != "")
                    {
                        var newScheduleWorkingTime = new ScheduleEquipmentWorkingTime();
                        string? fromString = item.Split('|')[0];
                        newScheduleWorkingTime.from = DateTime.ParseExact(fromString, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                        string? toString = item.Split('|')[1];
                        newScheduleWorkingTime.to = DateTime.ParseExact(toString, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                        ScheduleWorkingTimes.Add(newScheduleWorkingTime);
                    }
                }
                return ScheduleWorkingTimes;
            }

            return new List<ScheduleEquipmentWorkingTime>();

        }
    }

    public class ScheduleEquipmentWorkingTime
    {
        public DateTime from { get; set; }
        public DateTime to { get; set; }
    }

}
