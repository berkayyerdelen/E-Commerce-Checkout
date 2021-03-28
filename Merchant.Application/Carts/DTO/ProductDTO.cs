using Merchant.Application.Products.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Application.Carts.DTO
{
    public class ProductDTO
    {
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public MoneyDTO Money { get; set; }

    }
}
