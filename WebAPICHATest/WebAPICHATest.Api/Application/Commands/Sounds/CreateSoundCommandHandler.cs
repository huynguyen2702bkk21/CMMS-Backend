using WebAPICHATest.Api.Application.Commands.Sounds;
using WebAPICHATest.Domain.AggregateModels.SoundAggregate;

namespace WebAPICHATest.Api.Application.Commands.Sounds
{
    public class CreateSoundCommandHandler : IRequestHandler<CreateSoundCommand, bool>
    {
        private readonly ISoundRepository _soundRepository;

        public CreateSoundCommandHandler(ISoundRepository soundRepository)
        {
            _soundRepository = soundRepository;
        }

        public async Task<bool> Handle(CreateSoundCommand request, CancellationToken cancellationToken)
        {
            var sound = new Sound(request.SoundId, request.Value);
            _soundRepository.Add(sound);

            return await _soundRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
