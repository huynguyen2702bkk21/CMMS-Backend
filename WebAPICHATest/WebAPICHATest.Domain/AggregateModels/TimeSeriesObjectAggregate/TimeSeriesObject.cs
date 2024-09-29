namespace WebAPICHATest.Domain.AggregateModels.TimeSeriesObjectAggregate
{
    public class TimeSeriesObject : Entity, IAggregateRoot
    {
        public string? TimeSeriesObjectId { get; set; }
        public DateTime Time { get; set; }
        public decimal Value { get; set; }
        private TimeSeriesObject()
        {

        }

        public TimeSeriesObject(string? timeSeriesObjectId, DateTime time, decimal value)
        {
            TimeSeriesObjectId = timeSeriesObjectId;
            Time = time;
            Value = value;
        }

        public void Update(DateTime time, decimal value)
        {
            Time = time;
            Value = value;
        }
    }
}
