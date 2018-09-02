﻿using System;
using System.Collections.Generic;

namespace YouScan.Sales.Domain
{
    public class Money : ValueObject
    {
        public static Money Zero = new Money(0m);
        public static Money Dollar = new Money(1m);

        public decimal Amount { get; }

        public Money(decimal amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount));
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

        public Money Add(Money money)
        {
            if (money == null) throw new ArgumentNullException(nameof(money));
            return new Money(Amount + money.Amount);
        }

        public Money Multiply(decimal multiplier)
        {
            if (multiplier < 0) throw new ArgumentOutOfRangeException(nameof(multiplier));
            return new Money(Amount * multiplier);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
        }
    }
}