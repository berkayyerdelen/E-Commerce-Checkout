using Merchant.Domain.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Domain.Shared
{
    public class Money : ValueObject
    {
        public decimal Value { get; }
        public string CurrencyCode { get; }
        public string CurrencySymbol { get; set; }
        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
    public class Currency
    {
        public string Unit { get;}
        public Currency(string unit)
        {
            Unit = unit;
        }
        public static Currency TurkishLira => new Currency("TRY");
        public static Currency Euro => new Currency("€");
        public static Currency Dolar => new Currency("$");
    }
}
