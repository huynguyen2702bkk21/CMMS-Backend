using WebAPICHATest.Domain.AggregateModels.JsonPersonAggregate;
using WebAPICHATest.Domain.AggregateModels.WorkingTimeAggregate;

namespace WebAPICHATest.Api.Application.Queries.Persons
{
    public class PersonGetViewModel
    {
        public string PersonId { get; set; }
        public string PersonName { get; set; }
        public List<SchedulePersonWorkingTime>? ScheduleWorkingTimes { get; set; }


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private PersonGetViewModel() { }

        public PersonGetViewModel(string personId)
        {
            PersonId = personId;
        }

        public PersonGetViewModel(string personId, string personName, List<SchedulePersonWorkingTime>? scheduleWorkingTimes)
        {
            PersonId = personId;
            PersonName = personName;
            ScheduleWorkingTimes = scheduleWorkingTimes;
        }


#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
