using System.Collections;
using System.Collections.Generic;
using static YouScan.Sales.Domain.Money;

namespace YouScan.Sales.Domain.UnitTests
{
    public class UserChargeData : IEnumerable<object[]>
    {
        public DiscountProgram DiscountProgram { get; }
        public Money OneThousandDollarsPrice { get; }

        public UserChargeData()
        {
            DiscountProgram = DiscountProgram.Empty
                .AddDiscount(1000 * Dollar, 1)
                .AddDiscount(2000 * Dollar, 3)
                .AddDiscount(5000 * Dollar, 5)
                .AddDiscount(10000 * Dollar, 7);

            OneThousandDollarsPrice = 1000 * Dollar;
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                DiscountProgram, OneThousandDollarsPrice,
                new Account(1000 * Dollar), new Account(0 * Dollar),
                new DiscountCard(0 * Dollar), new DiscountCard(1000 * Dollar),
            };
            yield return new object[]
            {
                DiscountProgram, OneThousandDollarsPrice,
                new Account(1001 * Dollar), new Account(1 * Dollar),
                new DiscountCard(999.99m * Dollar), new DiscountCard(1999.99m * Dollar),
            };
            yield return new object[]
            {
                DiscountProgram, OneThousandDollarsPrice,
                new Account(1000 * Dollar), new Account(10 * Dollar),
                new DiscountCard(1000 * Dollar), new DiscountCard(2000 * Dollar),
            };
            yield return new object[]
            {
                DiscountProgram, OneThousandDollarsPrice,
                new Account(1000 * Dollar), new Account(30 * Dollar),
                new DiscountCard(2000 * Dollar), new DiscountCard(3000 * Dollar),
            };
            yield return new object[]
            {
                DiscountProgram, OneThousandDollarsPrice,
                new Account(1000 * Dollar), new Account(50 * Dollar),
                new DiscountCard(5000 * Dollar), new DiscountCard(6000 * Dollar),
            };
            yield return new object[]
            {
                DiscountProgram, OneThousandDollarsPrice,
                new Account(1000 * Dollar), new Account(70 * Dollar),
                new DiscountCard(10000 * Dollar), new DiscountCard(11000 * Dollar),
            };
            yield return new object[]
            {
                DiscountProgram, OneThousandDollarsPrice,
                new Account(1000 * Dollar), new Account(70 * Dollar),
                new DiscountCard(50000 * Dollar), new DiscountCard(51000 * Dollar),
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}