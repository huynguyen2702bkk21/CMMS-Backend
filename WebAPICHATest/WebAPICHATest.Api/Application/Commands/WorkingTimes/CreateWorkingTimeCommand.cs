using System.Runtime.Serialization;

namespace WebAPICHATest.Api.Application.Commands.WorkingTimes
{
    [DataContract]
    public class CreateWorkingTimeCommand : IRequest<bool>
    {
        public string? WorkingTimeId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public CreateWorkingTimeCommand(string? workingTimeId, DateTime? from, DateTime? to)
        {
            WorkingTimeId = workingTimeId;
            From = from;
            To = to;
        }
    }
}
