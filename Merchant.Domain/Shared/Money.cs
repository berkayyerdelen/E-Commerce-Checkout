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
        public Currency Unit { get; }
        public Money(decimal value, Currency unit)
        {
            Value = value;
            Unit = unit;
        }

        
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
            yield return Unit;
        }
    }
    public class Currency : ValueObject
    {
        public string Unit { get; }
        public Currency(string unit)
        {
            if (string.IsNullOrEmpty(unit))
                throw new BusinessException("Unit can not be null or empty.");
            Unit = unit;
        }
        public static Currency TurkishLira => new Currency("TRY");
        public static Currency Euro => new Currency("€");
        public static Currency Dolar => new Currency("$");
        public static List<string> SupportedCurrencies() => new() { TurkishLira.Unit, Euro.Unit, Dolar.Unit };
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Unit;
        }
    }
}
