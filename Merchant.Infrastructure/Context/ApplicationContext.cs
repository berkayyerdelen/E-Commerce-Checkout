using Merchant.Application.Interfaces;
using Merchant.Domain.Carts;
using Merchant.Domain.Categories;
using Merchant.Domain.Customers;
using Merchant.Domain.Products;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Infrastructure.Context
{
    public class ApplicationContext : IApplicationContext
    {
        private readonly IMongoDatabase _dateBase = null;
        public ApplicationContext(IOptions<MongoDbSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _dateBase = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<Cart> Carts => _dateBase.GetCollection<Cart>("Cart");
        public IMongoCollection<Product> Products => _dateBase.GetCollection<Product>("Product");
        public IMongoCollection<Category> Categories => _dateBase.GetCollection<Category>("Category");
        public IMongoCollection<Customer> Customers => _dateBase.GetCollection<Customer>("Customer");
    }
}
