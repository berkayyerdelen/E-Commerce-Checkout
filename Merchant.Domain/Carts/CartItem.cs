using Merchant.Domain.Core.Base;
using Merchant.Domain.Products;

namespace Merchant.Domain.Carts
{
    public class CartItem : Entity
    {
        protected CartItem(Product product, Quantity quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Product Product { get; private set; }
        public Quantity Quantity { get; private set; }

        public CartItem ChangeQuantity(Quantity quantity)
        {
            Quantity = quantity;
            return this;
        }
        public static CartItem CreateCartItem(Product product, Quantity quantity) => new CartItem(product, quantity);

    }
}
