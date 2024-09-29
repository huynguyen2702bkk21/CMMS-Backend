using WebAPICHATest.Api.Application.Commands.TimeSeriesObjects;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.TimeSeriesObjectAggregate;

namespace WebAPICHATest.Api.Application.Commands.TimeSeriesObjects
{
    public class UpdateTimeSeriesObjectCommandHandler : IRequestHandler<UpdateTimeSeriesObjectCommand, bool>
    {
        private readonly ITimeSeriesObjectRepository _soundRepository;

        public UpdateTimeSeriesObjectCommandHandler(ITimeSeriesObjectRepository soundRepository)
        {
            _soundRepository = soundRepository;
        }

        public async Task<bool> Handle(UpdateTimeSeriesObjectCommand request, CancellationToken cancellationToken)
        {
            var sound = await _soundRepository.GetById(request.TimeSeriesObjectId) ?? throw new NotFoundException();
            sound.Update(request.Time, request.Value);
            _soundRepository.Update(sound);

            return await _soundRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
