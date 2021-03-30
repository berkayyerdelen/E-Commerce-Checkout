using Merchant.Domain.Core.Base;
using System.Collections.Generic;

namespace Merchant.Domain.Customers
{
    public class FullName : ValueObject
    {
        public string FirstName { get; }

        public FullName(string firstName, string middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        public static FullName SetFullName(string firstName, string middleName, string lastName) => new FullName(firstName, middleName, lastName);
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
