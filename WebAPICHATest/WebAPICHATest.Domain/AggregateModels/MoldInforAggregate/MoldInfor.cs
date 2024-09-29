using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Domain.AggregateModels.ProductAggregate;
using WebAPICHATest.Domain.AggregateModels.StandardAggregate;

namespace WebAPICHATest.Domain.AggregateModels.MoldInforAggregate
{
    public class MoldInfor : Entity, IAggregateRoot
    {
        public string? MoldInforId { get; set; }
        public int? Cavity { get; set; }
        public string? DocumentLink { get; set; }
        public string? Images { get; set; }

        public MoldInfor(string? moldInforId, int? cavity, string? documentLink, string? images)
        {
            MoldInforId = moldInforId;
            Cavity = cavity;
            DocumentLink = documentLink;
            Images = images;
        }



#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private MoldInfor() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public void Update(int? cavity, string? documentLink, string? images)
        {
            if (cavity != null)
            {
                Cavity = cavity;

            }

            if (documentLink != null)
            {
                DocumentLink = documentLink;

            }

            if (images != null)
            {
                Images = images;
            }
        }
    }
}
