using System;
using System.Collections.Generic;

namespace PointOfSales.Domain
{
    public class DiscountCard : ValueObject
    {
        public Money MoneySpent { get; }

        public DiscountCard(Money moneySpent)
        {
            MoneySpent = moneySpent ?? throw new ArgumentNullException(nameof(moneySpent));
        }

        public DiscountCard RegisterPurchase(Money spent)
        {
            return new DiscountCard(MoneySpent + spent);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return MoneySpent;
        }
    }
}