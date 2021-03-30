using Merchant.Domain.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Domain.Carts
{
    public interface ICartRepository:IRepository<Cart>
    {
        Task InsertCartAsync(Cart cart);
        Task DeleteCartAsync(Expression<Func<Cart, bool>> expression);
        Task UpdateCartAsync(string cartId, Cart cart);
        Task<Cart> GetCartAsync(Expression<Func<Cart, bool>> expression = null);
        Task DeleteCartItemAsync(string cartId, string cartItemId);
    }
}
