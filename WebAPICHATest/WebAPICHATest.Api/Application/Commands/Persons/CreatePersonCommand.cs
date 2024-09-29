using static WebAPICHATest.Domain.AggregateModels.PersonAggregate.Person;
using System.Runtime.Serialization;
using WebAPICHATest.Domain.AggregateModels.WorkingTimeAggregate;

namespace WebAPICHATest.Api.Application.Commands.Persons
{
    [DataContract]
    public class CreatePersonCommand : IRequest<bool>
    {
        public string? PersonName { get; set; }
        public string? ScheduleWorkingTimes { get; set; }

        public CreatePersonCommand(string? personName, string? scheduleWorkingTimes)
        {
            PersonName = personName;
            ScheduleWorkingTimes = scheduleWorkingTimes;
        }
    }
}
