using Merchant.Domain.Carts;
using Merchant.Domain.Categories;
using Merchant.Domain.Customers;
using Merchant.Domain.Products;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Application.Interfaces
{
    public interface IApplicationContext
    {
        public IMongoCollection<Cart> Carts { get; }
        public IMongoCollection<Product> Products { get; }
        public IMongoCollection<Category> Categories { get; }
        public IMongoCollection<Customer> Customers { get; }
    }
}
