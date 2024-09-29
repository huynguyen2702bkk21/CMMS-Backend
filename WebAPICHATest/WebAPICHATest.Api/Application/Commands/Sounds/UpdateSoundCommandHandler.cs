using WebAPICHATest.Api.Application.Commands.Sounds;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.SoundAggregate;

namespace WebAPICHATest.Api.Application.Commands.Sounds
{
    public class UpdateSoundCommandHandler : IRequestHandler<UpdateSoundCommand, bool>
    {
        private readonly ISoundRepository _soundRepository;

        public UpdateSoundCommandHandler(ISoundRepository soundRepository)
        {
            _soundRepository = soundRepository;
        }

        public async Task<bool> Handle(UpdateSoundCommand request, CancellationToken cancellationToken)
        {
            var sound = await _soundRepository.GetById(request.SoundId) ?? throw new NotFoundException();
            sound.Update(request.Value);
            _soundRepository.Update(sound);

            return await _soundRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
