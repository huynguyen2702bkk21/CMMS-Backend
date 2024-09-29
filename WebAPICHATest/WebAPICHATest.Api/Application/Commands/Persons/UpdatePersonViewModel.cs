using WebAPICHATest.Domain.AggregateModels.WorkingTimeAggregate;
using static WebAPICHATest.Domain.AggregateModels.PersonAggregate.Person;

namespace WebAPICHATest.Api.Application.Commands.Persons
{
    public class UpdatePersonViewModel
    {
        public string? PersonId { get; set; }
        public string? PersonName { get; set; }
        public string? ScheduleWorkingTimes { get; set; }

        public UpdatePersonViewModel(string? personId, string? personName, string? scheduleWorkingTimes)
        {
            PersonId = personId;
            PersonName = personName;
            ScheduleWorkingTimes = scheduleWorkingTimes;
        }

        private UpdatePersonViewModel()
        {

        }
    }
}
