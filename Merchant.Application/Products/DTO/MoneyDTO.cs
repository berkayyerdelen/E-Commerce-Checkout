using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Application.Products.DTO
{
    public class MoneyDTO
    {
        public decimal Value { get; set; }
        public CurrencyDTO Unit { get; set; }
        public MoneyDTO(decimal value, CurrencyDTO unit)
        {
            Value = value;
            Unit = unit;
        }

    }
}
