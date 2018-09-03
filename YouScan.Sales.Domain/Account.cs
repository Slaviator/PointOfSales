using System;
using System.Collections.Generic;

namespace YouScan.Sales.Domain
{
    public class Account : ValueObject
    {
        public Money Amount { get; }

        public Account(Money amount)
        {
            Amount = amount ?? throw new ArgumentNullException(nameof(amount));
        }

        public Account Credit(Money amount)
        {
            if (amount == null) throw new ArgumentNullException(nameof(amount));
            return new Account(Amount - amount);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
        }
    }
}