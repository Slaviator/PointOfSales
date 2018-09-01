using System;

namespace YouScan.Sales.Domain
{
    public class TotalPrice
    {
        public decimal Amount { get; }

        public TotalPrice(decimal amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount));
            Amount = amount;
        }
    }
}