using MediatR;
using Merchant.Application.Carts.DTO;
using Merchant.Domain.Carts;
using Merchant.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Merchant.Application.Carts
{
    public class CreateCartCommand : IRequest
    {
        public CustomerDTO Customer { get; set; }
    }
    public sealed class CreateCartCommandHandler : IRequestHandler<CreateCartCommand>
    {
        private readonly ICartRepository _cartRepository;

        public CreateCartCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Unit> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            await _cartRepository.InsertCartAsync(new Cart(Customer.CreateCustomer(new Email(request.Customer.Email.Mail),
                  FullName.SetFullName(request.Customer.FullName.FirstName, 
                  request.Customer.FullName.MiddleName,
                  request.Customer.FullName.LastName))));
            return Unit.Value;
        }
    }
}
