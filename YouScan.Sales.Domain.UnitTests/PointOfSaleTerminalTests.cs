using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace YouScan.Sales.Domain.UnitTests
{
    public class PointOfSaleTerminalTests
    {
        [Theory, ClassData(typeof(MinimalInputData))]
        public void MinimalInput_ForSetPricing_ProducesCorrectPrice(
            IEnumerable<Product> products, Pricing pricing, TotalPrice total)
        {
            // Arrange
            var sut = new PointOfSaleTerminal(pricing);
            // todo: add batch scan operation
            foreach (var product in products)
            {
                sut.Scan(product);
            }

            // Act
            var actualTotal = sut.CalculateTotal();

            // Assert
            actualTotal.Should().NotBeNull().And.BeEquivalentTo(total);
        }
    }
}