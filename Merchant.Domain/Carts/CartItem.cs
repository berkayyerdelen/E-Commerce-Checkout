using Merchant.Domain.Core.Base;
using Merchant.Domain.Products;

namespace Merchant.Domain.Carts
{
    public class CartItem : Entity
    {
        protected CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Product Product { get; private set; }
        public int Quantity { get; private set; }

        public CartItem ChangeQuantity(int quantity)
        {
            Quantity = quantity;
            return this;
        }
        public static CartItem CreateCartItem(Product product, int quantity) => new CartItem(product, quantity);

    }
}
