using System;
using System.Collections.Generic;
using System.Linq;

namespace YouScan.Sales.Domain
{
    public class DiscountProgram : ValueObject
    {
        public static DiscountProgram Empty { get; } = new DiscountProgram(new[] {new Discount(Money.Zero, 0)});

        public IEnumerable<Discount> Discounts { get; }

        private DiscountProgram(IEnumerable<Discount> discounts)
        {
            Discounts = discounts;
        }

        public DiscountProgram AddDiscount(Discount discount)
        {
            if (discount == null) throw new ArgumentNullException(nameof(discount));

            if (discount.SpentThreshold <= Discounts.Last().SpentThreshold)
                throw new ArgumentException("Value must be higher than last.", nameof(discount.SpentThreshold));
            if (discount.DiscountPercent <= Discounts.Last().DiscountPercent)
                throw new ArgumentException("Value must be higher than last.", nameof(discount.DiscountPercent));

            return new DiscountProgram(new List<Discount>(Discounts) {discount});
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            foreach (var discount in Discounts)
            {
                yield return discount;
            }
        }
    }
}