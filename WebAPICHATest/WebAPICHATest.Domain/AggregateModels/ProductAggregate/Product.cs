using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPICHATest.Domain.AggregateModels.ProductAggregate
{
    public class Product : Entity, IAggregateRoot
    {
        public string? ProductId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public decimal? Quantity { get; set; }

        public Product(string? productId, string? code, string? name, decimal? quantity)
        {
            ProductId = productId;
            Code = code;
            Name = name;
            Quantity = quantity;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private Product() { }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


        public void Update(string? code, string? name, decimal? quantity)
        {
            Code = code;
            Name = name;
            Quantity = quantity;
        }
    }
}
