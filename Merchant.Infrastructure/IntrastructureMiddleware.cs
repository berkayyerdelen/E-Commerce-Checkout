using Merchant.Application.Interfaces;
using Merchant.Domain.Carts;
using Merchant.Domain.Categories;
using Merchant.Domain.Customers;
using Merchant.Domain.Products;
using Merchant.Infrastructure.Context;
using Merchant.Infrastructure.Services.Carts;
using Merchant.Infrastructure.Services.Categories;
using Merchant.Infrastructure.Services.Customers;
using Merchant.Infrastructure.Services.Products;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Infrastructure
{
    public static class IntrastructureMiddleware
    {
        public static void RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationContext, ApplicationContext>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
