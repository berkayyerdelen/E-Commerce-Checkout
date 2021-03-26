using Merchant.Domain.Core.Base;
using System.Collections.Generic;

namespace Merchant.Domain.Shared
{
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
