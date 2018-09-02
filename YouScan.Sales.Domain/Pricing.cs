using System;
using System.Collections.Generic;
using System.Linq;

namespace YouScan.Sales.Domain
{
    public class Pricing : ValueObject
    {
        public IEnumerable<ProductPrice> ProductPrices { get; }

        public Pricing(IEnumerable<ProductPrice> productPrices)
        {
            ProductPrices = productPrices ?? throw new ArgumentNullException(nameof(productPrices));
            var productPricesDistinctCount = ProductPrices.Select(pp => pp.ProductCode).Distinct().Count();
            var productPricesCount = ProductPrices.Count();
            if (productPricesCount != productPricesDistinctCount)
                throw new ArgumentOutOfRangeException(nameof(productPrices));
        }

        public IEnumerable<Money> CalculatePrices(IEnumerable<Product> products)
        {
            if (products == null) throw new ArgumentNullException(nameof(products));
            return ProductPrices.Select(pp => pp.CalculatePrice(products));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            foreach (var productPrice in ProductPrices)
            {
                yield return productPrice;
            }
        }
    }
}