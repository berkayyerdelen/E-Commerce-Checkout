using Merchant.Application.Interfaces;
using Merchant.Domain.Customers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Infrastructure.Services.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IApplicationContext _context;

        public CustomerRepository(IApplicationContext context)
        {
            _context = context;
        }

        public async Task DeleteCustomerAsync(Expression<Func<Customer, bool>> expression)
        {
            await _context.Customers.DeleteOneAsync(expression);
        }

        public async Task<Customer> GetCustomerAsync(Expression<Func<Customer, bool>> expression)
        {
            var result = await _context.Customers.FindAsync(expression);
            return result.FirstOrDefault();
        }

        public async Task InsertCustomerAsync(Customer customer)
        {
            await _context.Customers.InsertOneAsync(customer);
        }
    }
}
