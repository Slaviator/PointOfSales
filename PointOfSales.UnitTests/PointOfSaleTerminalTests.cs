using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace PointOfSales.Domain.UnitTests
{
    public class PointOfSaleTerminalTests
    {
        [Theory, ClassData(typeof(PointOfSaleTerminalMinimalInputData))]
        public void MinimalInput_ForSetPricing_ProducesCorrectPrice(
            IEnumerable<Product> products, Pricing pricing, Money total)
        {
            // Arrange
            var sut = new PointOfSaleTerminal(pricing);

            // Act
            sut.ScanMany(products);
            var actualTotal = sut.CalculateTotal();

            // Assert
            actualTotal.Should().NotBeNull().And.BeEquivalentTo(total);
        }
    }
}