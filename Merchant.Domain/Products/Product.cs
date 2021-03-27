using Merchant.Domain.Categories;
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
        public Category Category{ get; set; }
        protected Product(string name, Category category,Money price)
        {
            if (string.IsNullOrEmpty(name))
                throw new BusinessException("Name can not be null or empty");

            Name = name;
            Price = price ?? throw new ArgumentNullException(nameof(price));
            CreationDate = DateTime.UtcNow;
            Category = category;
        }
        public static Product CreateProduct(string name, Category category, Money price) => new Product(name,category, price);
    }
}
