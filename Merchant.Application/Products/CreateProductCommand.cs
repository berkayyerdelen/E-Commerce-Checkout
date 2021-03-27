using MediatR;
using Merchant.Domain.Categories;
using Merchant.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Merchant.Application.Products
{
    public class CreateProductCommand:IRequest
    {
        public string Name { get; private set; }
        public Money Price { get; private set; }
        public DateTime CreationDate { get; }
        public Category Category { get; set; }
    }
    public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        public Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
