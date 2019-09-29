using System;
using System.Collections.Generic;

namespace PointOfSales.Domain
{
    public class PointOfSaleTerminal
    {
        public Pricing Pricing { get; }
        private List<Product> ScannedProducts { get; }

        public PointOfSaleTerminal(Pricing pricing)
        {
            Pricing = pricing ?? throw new ArgumentNullException(nameof(pricing));
            ScannedProducts = new List<Product>();
        }

        public void Scan(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            ScannedProducts.Add(product);
        }

        public void ScanMany(IEnumerable<Product> products)
        {
            if (products == null) throw new ArgumentNullException(nameof(products));
            ScannedProducts.AddRange(products);
        }

        public Money CalculateTotal()
        {
            var prices = Pricing.CalculatePrices(ScannedProducts);
            return Money.Sum(prices);
        }
    }
}