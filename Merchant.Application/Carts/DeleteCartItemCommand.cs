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
    public class DeleteCartItemCommand:IRequest
    {
        public string CartId { get;set; }
        public string CartItemId { get; set; }
    }
    public sealed class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartItemCommand>
    {
        private readonly ICartRepository _cartRepository;

        public DeleteCartItemCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Unit> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
           await _cartRepository.DeleteCartItemAsync(request.CartId, request.CartItemId);
            return Unit.Value;
        }
    }
}
