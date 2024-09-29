namespace WebAPICHATest.Api.Application.Commands.Sounds
{
    public class UpdateSoundViewModel
    {
        public string SoundId { get; set; }
        public string Value { get; set; }

        public UpdateSoundViewModel(string soundId, string value)
        {
            SoundId = soundId;
            Value = value;
        }

        private UpdateSoundViewModel()
        {

        }
    }
}
