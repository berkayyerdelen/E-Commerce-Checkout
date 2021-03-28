using Merchant.Domain.Core.Base;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Domain.Customers
{
    public class Customer: Entity, IAggregateRoot
    {
        public Email Email { get; private set; }   
        public FullName FullName { get;private set; }
        protected Customer(Email email, FullName fullName)
        {
            Email = email;
            FullName = fullName;
        }
        public Customer ChangeName (FullName fullName)
        {
            FullName = fullName;
            return this;
        }
        public static Customer CreateCustomer(Email email, FullName fullName) => new Customer(email, fullName);

    }
}
