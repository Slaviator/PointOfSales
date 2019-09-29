using System;
using System.Collections.Generic;

namespace PointOfSales.Domain
{
    public class ProductCode : ValueObject
    {
        public string Code { get; }

        public ProductCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("Value can't be null or whitespace.", nameof(code));
            Code = code;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
        }
    }
}