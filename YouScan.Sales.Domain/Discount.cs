using System;
using System.Collections.Generic;

namespace YouScan.Sales.Domain
{
    public class Discount : ValueObject
    {
        public Money SpentThreshold { get; }
        public int DiscountPercent { get; }

        public Discount(Money spentThreshold, int discountPercent)
        {
            if (discountPercent < 0 || discountPercent > 100)
                throw new ArgumentOutOfRangeException(nameof(discountPercent), discountPercent,
                    "Value must be a natural percent amount.");
            SpentThreshold = spentThreshold ?? throw new ArgumentNullException(nameof(spentThreshold));
            DiscountPercent = discountPercent;
        }

        public Money ApplyOn(Money money)
        {
            if (money == null) throw new ArgumentNullException(nameof(money));
            return money - money / 100 * DiscountPercent;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return DiscountPercent;
            yield return SpentThreshold;
        }
    }
}