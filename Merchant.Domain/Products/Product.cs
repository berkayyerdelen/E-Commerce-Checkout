using Merchant.Domain.Core.Base;
using Merchant.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Domain.Products
{
    public class Product:Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public Money Price { get; private set; }
        public DateTime CreationDate { get; }

        protected Product(string name, Money price)
        {
            if (string.IsNullOrEmpty(name))
                throw new BusinessException("Name can not be null or empty");

            Name = name;
            Price = price ?? throw new ArgumentNullException(nameof(price));
            CreationDate = DateTime.UtcNow;
        }
        public static Product CreateProduct(string name, Money price) => new Product(name, price);
    }
}
