﻿using MediatR;
using Merchant.Domain.Customers;
using Merchant.Domain.Customers.UpsertCustomerCommandDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Merchant.Application.Customers
{
    public class CreateCustomerCommand:IRequest
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

        public Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            _customerRepository.InsertCustomerAsync(Customer.CreateCustomer(new Email(request.Email.Mail)
                , new FullName(request.FullName.FirstName, request.FullName.MiddleName, request.FullName.LastName)));
            return Unit.Task;
        }
    }
}