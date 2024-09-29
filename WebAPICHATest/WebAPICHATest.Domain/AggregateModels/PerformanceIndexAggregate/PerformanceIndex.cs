using WebAPICHATest.Domain.AggregateModels.TimeSeriesObjectAggregate;

namespace WebAPICHATest.Domain.AggregateModels.PerformanceIndexAggregate
{
    public class PerformanceIndex : Entity, IAggregateRoot
    {
        public string PerformanceIndexId { get; set; }
        public bool IsTracking { get; set; }
        public decimal RecentValue { get; set; }
        public List<TimeSeriesObject> History { get; set; }
        public int MaxLength { get; set; }

        private PerformanceIndex()
        {
        }

        public PerformanceIndex(string performanceIndexId)
        {
            PerformanceIndexId = performanceIndexId;
        }

        public PerformanceIndex(string performanceIndexId, bool isTracking, decimal recentValue, List<TimeSeriesObject> history, int maxLength)
        {
            PerformanceIndexId = performanceIndexId;
            IsTracking = isTracking;
            RecentValue = recentValue;
            History = history;
            MaxLength = maxLength;
        }

        public void Update(bool isTracking, decimal recentValue, List<TimeSeriesObject> history, int maxLength)
        {
            IsTracking = isTracking;
            RecentValue = recentValue;
            History = history;
            MaxLength = maxLength;
        }
    }
}
