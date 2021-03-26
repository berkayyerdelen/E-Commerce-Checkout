﻿using Merchant.Domain.Core.Base;
using Merchant.Domain.Customers;
using Merchant.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Domain.Carts
{
    public class Cart : Entity, IAggregateRoot
    {
        public Customer Customer { get; private set; }
        public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();
        private readonly List<CartItem> _items = new List<CartItem>();
        public Cart(Customer customer)
        {
            if (customer == null)
                throw new BusinessException("The customer is required.");

            Customer = customer;
        }
        public Cart AddItem(Product product, int quantity)
        {
            if (product is null) throw new BusinessException("The cart item must have a product");
            if (quantity <= 0) throw new BusinessException("The product quantity must be at last 1");
            var cartItem = CartItem.CreateCartItem(product, quantity);
            _items.Add(cartItem);
            return this;
        }
        public void RemoveItem(string cartItemId)
        {
            var cartItem = _items.FirstOrDefault(x => x.Id == cartItemId);
            if (cartItem is null) throw new BusinessException("Invalid cart item");
            _items.Remove(cartItem);
        }
        public Cart ChangeCart(Product product, int quantity)
        {
            if (product is null) throw new BusinessException("The cart item must have a product");
            var cartItem = _items.FirstOrDefault(x => x.Id == product.Id);
            if (cartItem is null) AddItem(product, quantity);
            else cartItem.ChangeQuantity(quantity);
            return this;
        }
        public void ClearCart() => _items.Clear();
      
    }
}
