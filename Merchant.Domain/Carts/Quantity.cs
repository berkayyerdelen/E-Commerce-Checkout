using Merchant.Domain.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Domain.Carts
{
    public class Quantity : ValueObject
    {
        public int ProductQuantity { get;}

        protected Quantity(int productQuantity)
        {
            ProductQuantity = productQuantity;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return ProductQuantity;
        }
        public static Quantity SetQuantity(int productQuantity) => new Quantity(productQuantity);
    }
}
