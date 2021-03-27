using Merchant.Application.Interfaces;
using Merchant.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
namespace Merchant.Infrastructure.Services.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IApplicationContext _context;

        public CategoryRepository(IApplicationContext context)
        {
            _context = context;
        }

        public async Task DeleteCategoryAsync(Expression<Func<Category, bool>> expression)
        {
            await _context.Categories.DeleteOneAsync(expression);
        }

        public async Task DeleteCategoryByIdAsync(string categoryId)
        {
            await _context.Categories.DeleteOneAsync(x => x.Id == categoryId);
        }

        public async Task<List<Category>> GetCategoriesAsync(Expression<Func<Category, bool>> expression)
        {
            var result = await _context.Categories.FindAsync(expression);
            return result.ToList();
        }

        public async Task InsertCategoryAsync(Category category)
        {
            await _context.Categories.InsertOneAsync(category);
        }

        public async Task UpdateCategoryAsync(string categoryId, Category category)
        {
            await _context.Categories.ReplaceOneAsync(x => x.Id == categoryId, category);
        }
    }
}
