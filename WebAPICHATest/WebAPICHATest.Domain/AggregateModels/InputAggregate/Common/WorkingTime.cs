namespace WebAPICHATest.Domain.AggregateModels.InputAggregate.Common
{
    public class WorkingTime
    {
        public DateTime from { get; set; }
        public DateTime to { get; set; }

        public WorkingTime(DateTime from, DateTime to)
        {
            this.from = from;
            this.to = to;
        }
    }
}
