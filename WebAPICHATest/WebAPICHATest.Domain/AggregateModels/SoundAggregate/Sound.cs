using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPICHATest.Domain.AggregateModels.SoundAggregate
{
    public class Sound : Entity, IAggregateRoot
    {
        public string? SoundId { get; set; }
        public string? Value { get; set; }

        private Sound()
        {

        }

        public Sound(string? soundId, string? value)
        {
            SoundId = soundId;
            Value = value;
        }

        public void Update(string? value)
        {
            Value = value;
        }
    }
}
