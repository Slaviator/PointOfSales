using System;
using System.Collections.Generic;

namespace YouScan.Sales.Domain
{
    public class ProductCode : ValueObject
    {
        public string Code { get; }

        public ProductCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(code));
            Code = code;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
        }
    }
}