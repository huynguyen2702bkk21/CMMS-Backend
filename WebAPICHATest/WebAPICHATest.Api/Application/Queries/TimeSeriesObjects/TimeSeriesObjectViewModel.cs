namespace WebAPICHATest.Api.Application.Queries.TimeSeriesObjects
{
    public class TimeSeriesObjectViewModel
    {
        public string? TimeSeriesObjectId { get; set; }
        public DateTime Time { get; set; }
        public decimal Value { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private TimeSeriesObjectViewModel() { }

        public TimeSeriesObjectViewModel(string? timeSeriesObjectId, DateTime time, decimal value)
        {
            TimeSeriesObjectId = timeSeriesObjectId;
            Time = time;
            Value = value;
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
