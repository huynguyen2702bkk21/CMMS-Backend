using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPICHATest.Domain.AggregateModels.SoundAggregate
{
    public interface ISoundRepository : IRepository<Sound>
    {
        Sound Add(Sound sound);
        Sound Update(Sound sound);
        Task<Sound?>? GetById(string sound);
        Task<List<Sound>>? GetListById(List<string> soundIds);
    }
}
