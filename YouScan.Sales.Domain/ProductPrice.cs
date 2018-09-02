using System;
using System.Collections.Generic;
using System.Linq;

namespace YouScan.Sales.Domain
{
    public class ProductPrice : ValueObject
    {
        public ProductCode ProductCode { get; }
        public UnitPrice UnitPrice { get; }
        public BatchPrice BatchPrice { get; }

        public ProductPrice(ProductCode productCode, UnitPrice unitPrice, BatchPrice batchPrice)
        {
            ProductCode = productCode ?? throw new ArgumentNullException(nameof(productCode));
            UnitPrice = unitPrice ?? throw new ArgumentNullException(nameof(unitPrice));
            BatchPrice = batchPrice ?? throw new ArgumentNullException(nameof(batchPrice));
        }

        public ProductPrice(ProductCode productCode, UnitPrice unitPrice)
            : this(productCode, unitPrice, unitPrice.ToBatchPrice())
        {
        }

        public Money CalculatePrice(IEnumerable<Product> products)
        {
            if (products == null) throw new ArgumentNullException(nameof(products));
            var productsCount = products.Count(p => p.Code == ProductCode);
            var batchesCount = productsCount / BatchPrice.BatchSize;
            var batchesPrice = BatchPrice.Price * batchesCount;
            var unitsCount = productsCount - (batchesCount * BatchPrice.BatchSize);
            var unitsPrice = UnitPrice.Price * unitsCount;
            return batchesPrice + unitsPrice;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return ProductCode;
            yield return UnitPrice;
            yield return BatchPrice;
        }
    }
}