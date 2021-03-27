using MediatR;
using Merchant.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Merchant.Application.Products
{
    public class DeleteProductCommand:IRequest
    {
        public string ProductId { get; set; }
    }
    public sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            _productRepository.DeleteProductAsync(x => x.Id == request.ProductId);
            return Unit.Task;
        }
    }
}
