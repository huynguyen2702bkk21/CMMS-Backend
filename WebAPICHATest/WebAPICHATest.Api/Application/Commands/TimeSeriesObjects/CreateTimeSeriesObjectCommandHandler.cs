using WebAPICHATest.Api.Application.Commands.TimeSeriesObjects;
using WebAPICHATest.Domain.AggregateModels.TimeSeriesObjectAggregate;

namespace WebAPICHATest.Api.Application.Commands.TimeSeriesObjects
{
    public class CreateTimeSeriesObjectCommandHandler : IRequestHandler<CreateTimeSeriesObjectCommand, bool>
    {
        private readonly ITimeSeriesObjectRepository _timeSeriesObjectRepository;

        public CreateTimeSeriesObjectCommandHandler(ITimeSeriesObjectRepository timeSeriesObjectRepository)
        {
            _timeSeriesObjectRepository = timeSeriesObjectRepository;
        }

        public async Task<bool> Handle(CreateTimeSeriesObjectCommand request, CancellationToken cancellationToken)
        {
            var timeSeriesObjectId = Guid.NewGuid().ToString();
            var timeSeriesObject = new TimeSeriesObject(timeSeriesObjectId: timeSeriesObjectId, 
                                                        time: request.Time, 
                                                        value: request.Value);
            _timeSeriesObjectRepository.Add(timeSeriesObject);

            return await _timeSeriesObjectRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
