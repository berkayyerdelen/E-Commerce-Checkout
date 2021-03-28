using MediatR;
using Merchant.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Merchant.Application.Customers
{
    public class DeleteCustomerCommand : IRequest
    {
        public string UserId { get; set; }

        public DeleteCustomerCommand(string userId)
        {
            UserId = userId;
        }
    }
    public sealed class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            await _customerRepository.DeleteCustomerAsync(x => x.Id == request.UserId);
            return Unit.Value;
        }
    }
}
