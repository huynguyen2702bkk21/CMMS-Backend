using WebAPICHATest.Api.Application.Commands.PerformanceIndexs;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.TimeSeriesObjectAggregate;
using WebAPICHATest.Domain.AggregateModels.PerformanceIndexAggregate;
using WebAPICHATest.Domain.AggregateModels.TimeSeriesObjectAggregate;

namespace WebAPICHATest.Api.Application.Commands.PerformanceIndexs
{
    public class CreatePerformanceIndexCommandHandler : IRequestHandler<CreatePerformanceIndexCommand, bool>
    {
        private readonly IPerformanceIndexRepository _performanceIndexRepository;
        private readonly ITimeSeriesObjectRepository _timeSeriesObjectRepository;

        public CreatePerformanceIndexCommandHandler(IPerformanceIndexRepository performanceIndexRepository, ITimeSeriesObjectRepository timeSeriesObjectRepository)
        {
            _performanceIndexRepository = performanceIndexRepository;
            _timeSeriesObjectRepository = timeSeriesObjectRepository;
        }

        public async Task<bool> Handle(CreatePerformanceIndexCommand request, CancellationToken cancellationToken)
        {
            var listTimeSeriesObject = new List<TimeSeriesObject>();
            foreach (string temp in request.History)
            {
                var timeSeriesObject = await _timeSeriesObjectRepository.GetById(temp) ?? throw new NotFoundException();
                listTimeSeriesObject.Add(timeSeriesObject);
            }

            var performanceIndexId = Guid.NewGuid().ToString();
            var performanceIndex = new PerformanceIndex(performanceIndexId: performanceIndexId, 
                                                        isTracking: request.IsTracking, 
                                                        recentValue: request.RecentValue, 
                                                        history: listTimeSeriesObject, 
                                                        maxLength: request.MaxLength);
            _performanceIndexRepository.Add(performanceIndex);

            return await _performanceIndexRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
