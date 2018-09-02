using System;
using System.Collections.Generic;

namespace YouScan.Sales.Domain
{
    public class PointOfSaleTerminal
    {
        public Pricing Pricing { get; }

        public PointOfSaleTerminal(Pricing pricing)
        {
            Pricing = pricing ?? throw new ArgumentNullException(nameof(pricing));
        }

        public void Scan(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
        }

        public void ScanMany(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                Scan(product);
            }
        }

        public Money CalculateTotal()
        {
            return new Money(0m);
        }
    }
}