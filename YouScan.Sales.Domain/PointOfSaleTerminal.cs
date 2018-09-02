using System;
using System.Collections.Generic;
using System.Linq;

namespace YouScan.Sales.Domain
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
            return Pricing
                .CalculatePrices(ScannedProducts)
                .Aggregate(Money.Zero, (m1, m2) => m1 + m2);
        }
    }
}