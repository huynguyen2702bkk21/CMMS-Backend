using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPICHATest.Domain.AggregateModels.KitTestAggregate
{
    public class KitTest : Entity, IAggregateRoot
    {
        public string? KitTestId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public KitTest(string? kitTestId, string code, string name)
        {
            KitTestId = kitTestId;
            Code = code;
            Name = name;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private KitTest() { }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


        public void Update(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}
