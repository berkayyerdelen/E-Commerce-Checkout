using Merchant.Domain.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Merchant.Domain.Products
{
    public interface IProductRepository:IRepository<Product>
    {
        Task InsertProductAsync(Product product);
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(string productId);
        Task UpdateProductAsync(string productId, Product product);
        Task<bool> DeleteProductAsync(Product product);
        Task<bool> DeleteProductByIdAsync(string productId);
    }
}
