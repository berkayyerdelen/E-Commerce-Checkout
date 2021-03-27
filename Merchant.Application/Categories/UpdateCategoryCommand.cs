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
    public class UpdateCategoryCommand : IRequest
    {
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryRepository.UpdateCategoryAsync(request.CategoryId, Category.CreateCategory(request.Name, request.Description));
            return Unit.Value;
        }
    }
}
