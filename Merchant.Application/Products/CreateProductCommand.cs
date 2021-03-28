using MediatR;
using Merchant.Application.Products.DTO;
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
    public class CreateProductCommand : IRequest
    {
        public string Name { get; set; }
        public MoneyDTO Price { get; set; }
        public CategoryDTO Category { get; set; }
    }


    public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            _productRepository.InsertProductAsync(Product.CreateProduct(request.Name, Category.CreateCategory(
                request.Category.CategoryName,
                request.Category.Description), 
                new Money(request.Price.Value,
                new Currency(request.Price.Unit.Unit))));
            return Unit.Task;
        }
    }
}
