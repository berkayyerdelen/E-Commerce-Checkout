using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Application.Customers.DTO
{
    public class EmailDTO
    {
        public string Mail { get;  set; }

        public EmailDTO(string mail)
        {
            Mail = mail;
        }
    }
}
