using FluentAssertions;
using Xunit;

namespace PointOfSales.Domain.UnitTests
{
    public class UserChargeTests
    {
        [Theory, ClassData(typeof(UserChargeData))]
        public void UserWithSufficientAccount_GotCharged_AccountAndDiscountCardAmountsAlter(
            DiscountProgram discountProgram,
            Money price,
            Account accountBeforeCharge,
            Account accountAfterCharge,
            DiscountCard discountCardBeforeCharge,
            DiscountCard discountCardAfterCharge)
        {
            // Arrange
            var sut = new User(discountCardBeforeCharge, accountBeforeCharge);

            // Act
            sut.Charge(price, discountProgram);

            // Assert
            sut.DiscountCard.Should().NotBeNull().And.BeEquivalentTo(discountCardAfterCharge);
            sut.Account.Should().NotBeNull().And.BeEquivalentTo(accountAfterCharge);
        }
    }
}