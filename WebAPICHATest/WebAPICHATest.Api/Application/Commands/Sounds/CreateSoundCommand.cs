using System.Runtime.Serialization;

namespace WebAPICHATest.Api.Application.Commands.Sounds
{
    [DataContract]
    public class CreateSoundCommand : IRequest<bool>
    {
        public string SoundId { get; set; }
        public string Value { get; set; }

        public CreateSoundCommand(string soundId, string value)
        {
            SoundId = soundId;
            Value = value;
        }
    }
}
