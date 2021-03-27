using MediatR;
using Merchant.Domain.Categories;
using Merchant.Domain.Products;
using Merchant.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Merchant.Application.Products
{
    public class UpdateProductCommand:IRequest
    {
        public string Id { get; set; }
        public string Name { get; private set; }
        public Money Price { get; private set; }
        public Category Category { get; set; }
    }
    public sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.UpdateProductAsync(request.Id, Product.CreateProduct(request.Name, request.Category, request.Price);
            return Unit.Task;
        }
    }
}
