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

        public async Task DeleteProductAsync(Expression<Func<Product, bool>> expression)
        {
            await _context.Products.DeleteOneAsync(expression);
        }

        public async Task DeleteProductByIdAsync(string productId)
        {
           await _context.Products.DeleteOneAsync(x => x.Id == productId);
        }

        public async Task<Product> GetProductAsync(Expression<Func<Product, bool>> expression = null)
        {
            var result = await _context.Products.FindAsync(expression);
            return result.FirstOrDefault();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var products = await _context.Products.FindAsync(x=> true);
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
