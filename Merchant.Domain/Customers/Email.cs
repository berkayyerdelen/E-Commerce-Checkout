using Merchant.Domain.Core.Base;
using System;
using System.Collections.Generic;

namespace Merchant.Domain.Customers
{
    public class Email : ValueObject
    {
        public string MailName { get;private set; }
        public DateTime CreationDate { get; private set; }
        protected Email(string mailName)
        {
            if (string.IsNullOrEmpty(mailName))
                throw new BusinessException("Emeail can not be null or empty");
            MailName = mailName;
            CreationDate = DateTime.UtcNow;
        }
        public static Email CreateEmail(string mailName) => new Email(mailName);

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return MailName;
            yield return CreationDate;
        }
    }
}
