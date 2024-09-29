using static WebAPICHATest.Domain.AggregateModels.PersonAggregate.Person;
using System.Runtime.Serialization;
using WebAPICHATest.Domain.AggregateModels.WorkingTimeAggregate;

namespace WebAPICHATest.Api.Application.Commands.Persons
{
    [DataContract]
    public class UpdatePersonCommand : IRequest<bool>
    {
        public string? PersonId { get; set; }
        public string? PersonName { get; set; }
        public string? ScheduleWorkingTimes { get; set; }

        public UpdatePersonCommand(string? personId, string? personName, string? scheduleWorkingTimes)
        {
            PersonId = personId;
            PersonName = personName;
            ScheduleWorkingTimes = scheduleWorkingTimes;
        }
    }
}
