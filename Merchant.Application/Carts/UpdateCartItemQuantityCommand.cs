using MediatR;
using Merchant.Domain.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Merchant.Application.Carts
{
    public class UpdateCartItemQuantityCommand : IRequest
    {
        public string CustomerId { get; set; }
        public string CartItemId { get; set; }
        public int Quantity { get; set; }
    }
    public sealed class UpdateProductQuantityCommandHandler : IRequestHandler<UpdateCartItemQuantityCommand>
    {
        private readonly ICartRepository _cartRepository;

        public UpdateProductQuantityCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Unit> Handle(UpdateCartItemQuantityCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetCartAsync(x => x.Customer.Id == request.CustomerId);
            cart.ChangeCart(request.CartItemId, Quantity.SetQuantity(request.Quantity));
            await _cartRepository.UpdateCartAsync(cart.Id, cart);
            return Unit.Value;
        }
    }
}
