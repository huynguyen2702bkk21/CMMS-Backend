namespace WebAPICHATest.Api.Application.Queries.Sounds
{
    public class SoundViewModel
    {
        public string SoundId { get; set; }
        public string Value { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private SoundViewModel() { }

        public SoundViewModel(string soundId, string value)
        {
            SoundId = soundId;
            Value = value;
        }


#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
