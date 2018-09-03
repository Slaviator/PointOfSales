using System;

namespace YouScan.Sales.Domain
{
    public class User
    {
        public DiscountCard DiscountCard { get; private set; }
        public Account Account { get; private set; }

        public User(DiscountCard discountCard, Account account)
        {
            DiscountCard = discountCard ?? throw new ArgumentNullException(nameof(discountCard));
            Account = account ?? throw new ArgumentNullException(nameof(account));
        }

        public void Charge(Money price, DiscountProgram discountProgram)
        {
            if (price == null) throw new ArgumentNullException(nameof(price));
            if (discountProgram == null) throw new ArgumentNullException(nameof(discountProgram));

            var toCredit = discountProgram
                .GetBestDiscount(DiscountCard)
                .ApplyOn(price);

            Account = Account.Credit(toCredit);

            DiscountCard = DiscountCard.RegisterPurchase(price);
        }
    }
}