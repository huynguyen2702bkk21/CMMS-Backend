namespace WebAPICHATest.Api.Application.Queries.WorkingTimes
{
    public class WorkingTimeViewModel
    {
        public string? WorkingTimeId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private WorkingTimeViewModel() { }

        public WorkingTimeViewModel(string? workingTimeId, DateTime? from, DateTime? to)
        {
            WorkingTimeId = workingTimeId;
            From = from;
            To = to;
        }


#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
