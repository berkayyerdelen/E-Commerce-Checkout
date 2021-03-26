using Merchant.Application.Interfaces;
using Merchant.Domain.Products;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Infrastructure.Services.Products
{
    public class ProductRepository : IProductRepository
    {
        public IApplicationContext _context;

        public ProductRepository(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteProductAsync(Product product)
        {
            var filter = Builders<Product>.Filter.Eq(x => x, product);
            var result = await _context.Products.DeleteOneAsync(filter);
            return result.IsAcknowledged;
        }

        public async Task<bool> DeleteProductByIdAsync(string productId)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.Id, productId);
            var result = await _context.Products.DeleteOneAsync(filter);
            return result.IsAcknowledged;
        }

        public async Task<Product> GetProductAsync(string productId)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.Id, productId);
            var product = await _context.Products.FindAsync(filter);
            return product.FirstOrDefault();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var products = await _context.Products.FindAsync(new BsonDocument());
            return products.ToList();
        }

        public async Task InsertProductAsync(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task UpdateProductAsync(string productId, Product product)
        {
            await _context.Products.ReplaceOneAsync(x => x.Id == productId, product);
        }
    }
}
