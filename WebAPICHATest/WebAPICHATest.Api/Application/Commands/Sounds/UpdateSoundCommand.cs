using System.Runtime.Serialization;

namespace WebAPICHATest.Api.Application.Commands.Sounds
{
    [DataContract]
    public class UpdateSoundCommand : IRequest<bool>
    {
        public string SoundId { get; set; }
        public string Value { get; set; }

        public UpdateSoundCommand(string soundId, string value)
        {
            SoundId = soundId;
            Value = value;
        }
    }
}
