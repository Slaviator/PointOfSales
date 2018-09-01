using System;

namespace YouScan.Sales.Domain
{
    public class Product
    {
        public ProductCode Code { get; }

        public Product(ProductCode code)
        {
            Code = code ?? throw new ArgumentNullException(nameof(code));
        }
    }
}