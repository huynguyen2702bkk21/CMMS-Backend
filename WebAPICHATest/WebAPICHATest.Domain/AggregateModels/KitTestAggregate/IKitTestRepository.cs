using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.KitTestAggregate;

namespace WebAPICHATest.Domain.AggregateModels.KitTestAggregate
{
    public interface IKitTestRepository : IRepository<KitTest>
    {
        KitTest Add(KitTest equipment);
        KitTest Update(KitTest equipment);
        Task<KitTest?> GetById(string equipmentId);
    }
}
