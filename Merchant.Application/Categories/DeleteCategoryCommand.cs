using MediatR;
using Merchant.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Merchant.Application.Categories
{
    public class DeleteCategoryCommand:IRequest
    {
        public string CategoryId { get; set; }
    }
    public sealed class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryRepository.DeleteCategoryAsync(x => x.Id == request.CategoryId);
            return Unit.Value;
        }
    }
}
