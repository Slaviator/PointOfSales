using System;
using System.Collections.Generic;

namespace PointOfSales.Domain
{
    public class UnitPrice : ValueObject
    {
        public Money Price { get; }

        public UnitPrice(Money price)
        {
            Price = price ?? throw new ArgumentNullException(nameof(price));
        }

        public BatchPrice ToBatchPrice()
        {
            return new BatchPrice(Price, 1);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Price;
        }
    }
}