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
        protected Money(decimal value, Currency unit)
        {
            Value = value;
            Unit = unit;
        }
        public static Money SetMoney(decimal value, Currency unit) => new Money(value, unit);


        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
            yield return Unit;
        }
    }
}
