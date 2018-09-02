using System;
using System.Collections.Generic;

namespace YouScan.Sales.Domain
{
    public class Product : ValueObject
    {
        public ProductCode Code { get; }

        public Product(ProductCode code)
        {
            Code = code ?? throw new ArgumentNullException(nameof(code));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
        }
    }
}