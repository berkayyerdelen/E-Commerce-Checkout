using Merchant.Domain.Customers.UpsertCustomerCommandDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Application.Carts.DTO
{
 
    public class CustomerDTO
    {
        public EmailDTO Email { get; set; }
        public FullNameDTO FullName { get; set; }
    }
}
