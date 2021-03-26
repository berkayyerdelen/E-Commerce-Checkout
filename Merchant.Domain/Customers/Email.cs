using Merchant.Domain.Core.Base;
using System;
using System.Collections.Generic;

namespace Merchant.Domain.Customers
{
    public class Email : ValueObject
    {
        public string MailName { get;private set; }
        public DateTime CreationDate { get; private set; }
        public Email(string mailName)
        {
            if (string.IsNullOrEmpty(mailName))
                throw new BusinessException("Emeail can not be null or empty");
            MailName = mailName;
            CreationDate = DateTime.UtcNow;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return MailName;
            yield return CreationDate;
        }
    }
}
