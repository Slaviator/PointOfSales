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
                throw new ArgumentException("Value must be higher than previous.", nameof(discount.SpentThreshold));
            if (discount.DiscountPercent <= Discounts.Last().DiscountPercent)
                throw new ArgumentException("Value must be higher than previous.", nameof(discount.DiscountPercent));

            return new DiscountProgram(new List<Discount>(Discounts) {discount});
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