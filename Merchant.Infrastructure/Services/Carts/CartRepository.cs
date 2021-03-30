using Merchant.Application.Interfaces;
using Merchant.Domain.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
namespace Merchant.Infrastructure.Services.Carts
{
    public class CartRepository : ICartRepository
    {
        private readonly IApplicationContext _context;

        public CartRepository(IApplicationContext context)
        {
            _context = context;
        }

        public async Task DeleteCartAsync(Expression<Func<Cart, bool>> expression)
            => await _context.Carts.DeleteOneAsync(expression);

        public async Task DeleteCartItemAsync(string cartId, string cartItemId)
        {
            var update = Builders<Cart>.Update.PullFilter(p => p.Items,
                                                 f => f.Id == cartItemId);
            var result = await _context.Carts.FindOneAndUpdateAsync(x => x.Id == cartId, update);

        }

        public async Task<Cart> GetCartAsync(Expression<Func<Cart, bool>> expression)
        {
            var result = await _context.Carts.FindAsync(expression);
            return result.FirstOrDefault();
        }


        public async Task InsertCartAsync(Cart cart)
        {
            await _context.Carts.InsertOneAsync(cart);
        }

        public async Task UpdateCartAsync(string cartId, Cart cart)
        {
            await _context.Carts.ReplaceOneAsync(x => x.Id == cartId, cart);
        }
    }
}
