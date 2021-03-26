using Merchant.Domain.Core.Base;
using System.Collections.Generic;

namespace Merchant.Domain.Customers
{
    public class FullName : ValueObject
    {
        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FirstName;
            yield return MiddleName;
            yield return LastName;
        }
    }
}
