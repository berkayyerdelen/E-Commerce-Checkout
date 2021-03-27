using Merchant.Domain.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Domain.Customers
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task InsertCustomerAsync(Customer customer);
        Task<Customer> GetCustomerAsync(Expression<Func<Customer, bool>> expression);
        Task DeleteCustomerAsync(Expression<Func<Customer, bool>> expression);
    }
}
