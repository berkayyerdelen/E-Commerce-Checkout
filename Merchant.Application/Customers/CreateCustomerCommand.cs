using MediatR;
using Merchant.Application.Customers.DTO;
using Merchant.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Merchant.Application.Customers
{
    public class CreateCustomerCommand : IRequest
    {
        public EmailDTO Email { get; set; }
        public FullNameDTO FullName { get; set; }
    }
    public class CreateUserCommandHandler : IRequestHandler<CreateCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateUserCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _customerRepository.InsertCustomerAsync(Customer.CreateCustomer(Email.CreateEmail(request.Email.Mail)
                 , FullName.SetFullName(request.FullName.FirstName, request.FullName.MiddleName, request.FullName.LastName)));
            return Unit.Value;
        }
    }
}
