using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.WorkingTimeAggregate;
//using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.ConstantDomain;

namespace WebAPICHATest.Domain.AggregateModels.PersonAggregate
{
    public class Person : Entity, IAggregateRoot
    {
        public string? PersonId { get; set; }
        public string? PersonName { get; set; }
        public string? ScheduleWorkingTimes { get; set; }

        public Person(string? personId)
        {
            PersonId = personId;
        }

        public Person(string? personId, string? personName, string? scheduleWorkingTimes)
        {
            PersonId = personId;
            PersonName = personName;
            ScheduleWorkingTimes = scheduleWorkingTimes;
        }



#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Person() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public void Update(string? personName, string? scheduleWorkingTimes)
        {
            if (personName != null)
            {
                PersonName = personName;

            }

            if (scheduleWorkingTimes != null)
            {
                ScheduleWorkingTimes = scheduleWorkingTimes;
            }
        }
    }
}
