using System;
using System.Collections.Generic;
using System.Linq;

namespace YouScan.Sales.Domain
{
    public class Money : ValueObject
    {
        public static Money Zero { get; } = new Money(0m);
        public static Money Dollar { get; } = new Money(1m);

        public decimal Amount { get; }

        public Money(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount), amount, "Value can't be negative.");
            Amount = amount;
        }

        public static Money operator +(Money left, Money right)
        {
            if (left == null) throw new ArgumentNullException(nameof(left));
            if (right == null) throw new ArgumentNullException(nameof(right));
            return left.Add(right);
        }

        public static Money operator *(Money left, decimal multiplier)
        {
            if (left == null) throw new ArgumentNullException(nameof(left));
            return left.Multiply(multiplier);
        }

        public static Money operator *(decimal multiplier, Money left)
        {
            if (left == null) throw new ArgumentNullException(nameof(left));
            return left.Multiply(multiplier);
        }

        public static Money Sum(IEnumerable<Money> money)
        {
            if (money == null) throw new ArgumentNullException(nameof(money));
            return money.Aggregate(Zero, (m1, m2) => m1 + m2);
        }

        public Money Add(Money money)
        {
            if (money == null) throw new ArgumentNullException(nameof(money));
            return new Money(Amount + money.Amount);
        }

        public Money Multiply(decimal multiplier)
        {
            if (multiplier < 0)
                throw new ArgumentOutOfRangeException(nameof(multiplier), multiplier, "Value can't be negative.");
            return new Money(Amount * multiplier);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
        }
    }
}