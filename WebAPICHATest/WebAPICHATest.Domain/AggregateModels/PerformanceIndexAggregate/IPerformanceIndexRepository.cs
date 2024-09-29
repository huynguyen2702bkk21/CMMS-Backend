using WebAPICHATest.Domain.AggregateModels.PerformanceIndexAggregate;

namespace WebAPICHATest.Domain.AggregateModels.PerformanceIndexAggregate
{
    public interface IPerformanceIndexRepository : IRepository<PerformanceIndex>
    {
        PerformanceIndex Add(PerformanceIndex performanceIndex);
        PerformanceIndex Update(PerformanceIndex performanceIndex);
        Task<PerformanceIndex?> GetById(string performanceIndexId);
    }
}
