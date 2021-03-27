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
    public class GetProductsQuery:IRequest<List<Product>>
    {
    }
    public sealed class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductsAsync();
        }
    }
}
