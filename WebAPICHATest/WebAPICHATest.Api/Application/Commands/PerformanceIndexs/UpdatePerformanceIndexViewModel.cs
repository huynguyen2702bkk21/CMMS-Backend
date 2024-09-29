using static WebAPICHATest.Domain.AggregateModels.PerformanceIndexAggregate.PerformanceIndex;

namespace WebAPICHATest.Api.Application.Commands.PerformanceIndexs
{
    public class UpdatePerformanceIndexViewModel
    {
        public string PerformanceIndexId { get; set; }
        public bool IsTracking { get; set; }
        public decimal RecentValue { get; set; }
        public List<string> History { get; set; }
        public int MaxLength { get; set; }

        public UpdatePerformanceIndexViewModel(string performanceIndexId, bool isTracking, decimal recentValue, List<string> history, int maxLength)
        {
            PerformanceIndexId = performanceIndexId;
            IsTracking = isTracking;
            RecentValue = recentValue;
            History = history;
            MaxLength = maxLength;
        }

        private UpdatePerformanceIndexViewModel()
        {

        }
    }
}
