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
    public class CreateCategoryCommand : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryRepository.InsertCategoryAsync(Category.CreateCategory(request.Name, request.Description));
            return Unit.Task;
        }
    }
}
