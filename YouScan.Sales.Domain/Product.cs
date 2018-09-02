using System;
using System.Collections.Generic;

namespace YouScan.Sales.Domain
{
    public class Product : ValueObject
    {
        public static readonly Product A = new Product(new ProductCode("A"));
        public static readonly Product B = new Product(new ProductCode("B"));
        public static readonly Product C = new Product(new ProductCode("C"));
        public static readonly Product D = new Product(new ProductCode("D"));

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