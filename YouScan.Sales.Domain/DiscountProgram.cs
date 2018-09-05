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

        public DiscountProgram AddDiscount(Money spentThreshold, int discountPercent)
        {
            if (spentThreshold == null) throw new ArgumentNullException(nameof(spentThreshold));

            if (spentThreshold <= Discounts.Last().SpentThreshold)
                throw new ArgumentOutOfRangeException(nameof(spentThreshold), spentThreshold,
                    "Value must be higher than previous.");
            if (discountPercent <= Discounts.Last().DiscountPercent)
                throw new ArgumentOutOfRangeException(nameof(discountPercent), discountPercent,
                    "Value must be higher than previous.");

            return new DiscountProgram(new List<Discount>(Discounts) {new Discount(spentThreshold, discountPercent)});
        }

        public Discount GetBestDiscount(DiscountCard discountCard)
        {
            if (discountCard == null) throw new ArgumentNullException(nameof(discountCard));
            return Discounts.Last(discount => discountCard.MoneySpent >= discount.SpentThreshold);
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