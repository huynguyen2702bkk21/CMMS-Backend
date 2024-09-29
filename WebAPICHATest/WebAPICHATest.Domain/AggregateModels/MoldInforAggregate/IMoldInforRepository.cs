using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.MoldInforAggregate;

namespace WebAPICHATest.Domain.AggregateModels.MoldInforAggregate
{
    public interface IMoldInforRepository : IRepository<MoldInfor>
    {
        MoldInfor Add(MoldInfor moldInfor);
        MoldInfor Update(MoldInfor moldInfor);
        Task<MoldInfor?> GetById(string moldInforId);
    }
}
