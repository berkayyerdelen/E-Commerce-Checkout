using Merchant.Domain.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Domain.Categories
{
    public interface ICategoryRepository:IRepository<Category>
    {
        Task InsertCategoryAsync(Category category);
        Task<List<Category>> GetCategoriesAsync(Expression<Func<Category, bool>> expression=null);
        Task DeleteCategoryAsync(Expression<Func<Category, bool>> expression =null);
        Task DeleteCategoryByIdAsync(string categoryId);
        Task UpdateCategoryAsync(string categoryId, Category category);
    }
}
