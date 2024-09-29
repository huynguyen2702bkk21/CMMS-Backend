namespace WebAPICHATest.Api.Application.Commands.WorkingTimes
{
    public class UpdateWorkingTimeViewModel
    {
        public string? WorkingTimeId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public UpdateWorkingTimeViewModel(string? workingTimeId, DateTime? from, DateTime? to)
        {
            WorkingTimeId = workingTimeId;
            From = from;
            To = to;
        }

        private UpdateWorkingTimeViewModel()
        {

        }
    }
}
