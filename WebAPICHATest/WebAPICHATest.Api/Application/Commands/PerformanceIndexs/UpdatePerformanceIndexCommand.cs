using static WebAPICHATest.Domain.AggregateModels.PerformanceIndexAggregate.PerformanceIndex;
using System.Runtime.Serialization;

namespace WebAPICHATest.Api.Application.Commands.PerformanceIndexs
{
    [DataContract]
    public class UpdatePerformanceIndexCommand : IRequest<bool>
    {
        public string PerformanceIndexId { get; set; }
        public bool IsTracking { get; set; }
        public decimal RecentValue { get; set; }
        public List<string> History { get; set; }
        public int MaxLength { get; set; }

        public UpdatePerformanceIndexCommand(string performanceIndexId, bool isTracking, decimal recentValue, List<string> history, int maxLength)
        {
            PerformanceIndexId = performanceIndexId;
            IsTracking = isTracking;
            RecentValue = recentValue;
            History = history;
            MaxLength = maxLength;
        }
    }
}
