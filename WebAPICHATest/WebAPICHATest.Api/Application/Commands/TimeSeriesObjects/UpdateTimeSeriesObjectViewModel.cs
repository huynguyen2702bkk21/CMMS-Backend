namespace WebAPICHATest.Api.Application.Commands.TimeSeriesObjects
{
    public class UpdateTimeSeriesObjectViewModel
    {
        public string? TimeSeriesObjectId { get; set; }
        public DateTime Time { get; set; }
        public decimal Value { get; set; }

        public UpdateTimeSeriesObjectViewModel(string? timeSeriesObjectId, DateTime time, decimal value)
        {
            TimeSeriesObjectId = timeSeriesObjectId;
            Time = time;
            Value = value;
        }

        private UpdateTimeSeriesObjectViewModel()
        {

        }
    }
}
