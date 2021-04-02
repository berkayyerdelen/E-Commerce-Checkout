using Merchant.Domain.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Domain.Categories
{
    public class Category : Entity, IAggregateRoot
    {
        public string Name { get; private set; }

        protected Category(string name, string description)
        {
            if (string.IsNullOrEmpty(name)) throw new BusinessException("Category name can not be null");
            Name = name;
            Description = description;
        }

        public string Description { get; private set; }
        public static Category CreateCategory(string name, string description) => new Category(name, description);

    }
}
