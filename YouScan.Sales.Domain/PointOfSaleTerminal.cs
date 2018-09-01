using System;

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

        public TotalPrice CalculateTotal()
        {
            return new TotalPrice(0m);
        }
    }
}