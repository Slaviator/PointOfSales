using System;
using FluentAssertions;
using Xunit;
using static YouScan.Sales.Domain.Money;

namespace YouScan.Sales.Domain.UnitTests
{
    public class DiscountProgramTests
    {
        [Fact]
        public void NewDiscountProgram_BuiltProperly_NotThrowAndNotNull()
        {
            // Arrange
            var sut = DiscountProgram.Empty;

            // Act
            Action act = () =>
            {
                sut = sut
                    .AddDiscount(new Discount(1000 * Dollar, 1))
                    .AddDiscount(new Discount(2000 * Dollar, 3))
                    .AddDiscount(new Discount(5000 * Dollar, 5))
                    .AddDiscount(new Discount(10000 * Dollar, 7));
            };

            // Assert
            act.Should().NotThrow();
            sut.Should().NotBeNull();
        }
    }
}