using MediatR;
using Merchant.Application.Carts.DTO;
using Merchant.Application.Products.DTO;
using Merchant.Domain.Carts;
using Merchant.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Merchant.Application.Carts
{
    public class AddItemCartCommand : IRequest
    {
        public string UserId { get; set; }
        public ProductDTO Product { get; set; }
        public CategoryDTO Category { get; set; }
    }
    public sealed class AddItemCartCommandHandler : IRequestHandler<AddItemCartCommand>
    {
        private readonly ICartRepository _cartRepository;


        public AddItemCartCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Unit> Handle(AddItemCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetCartAsync(x => x.Customer.Id == request.UserId);

            cart.AddItem(Domain.Products.Product.CreateProduct(request.Product.ProductName,
                 Domain.Categories.Category.CreateCategory(request.Category.CategoryName, request.Category.Description),
                 Money.SetMoney(request.Product.Money.Value, 
                 Currency.SetCurrency(request.Product.Money.Unit.Unit))),
                 Quantity.SetQuantity(request.Product.Quantity));                
            await _cartRepository.UpdateCartAsync(cart.Id, cart);
            return Unit.Value;

        }
    }
}
