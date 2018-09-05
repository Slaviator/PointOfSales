using System.Collections;
using System.Collections.Generic;
using static YouScan.Sales.Domain.Money;

namespace YouScan.Sales.Domain.UnitTests
{
    public class PointOfSaleTerminalMinimalInputData : IEnumerable<object[]>
    {
        public Pricing Pricing { get; }
        public Product A { get; }
        public Product B { get; }
        public Product C { get; }
        public Product D { get; }

        public PointOfSaleTerminalMinimalInputData()
        {
            A = new Product(new ProductCode("A"));
            B = new Product(new ProductCode("B"));
            C = new Product(new ProductCode("C"));
            D = new Product(new ProductCode("D"));

            Pricing = new Pricing(new List<ProductPrice>
            {
                new ProductPrice(A.Code, new UnitPrice(1.25m * Dollar), new BatchPrice(3.0m * Dollar, 3)),
                new ProductPrice(B.Code, new UnitPrice(4.25m * Dollar)),
                new ProductPrice(C.Code, new UnitPrice(1.0m * Dollar), new BatchPrice(5.0m * Dollar, 6)),
                new ProductPrice(D.Code, new UnitPrice(0.75m * Dollar)),
            });
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new List<Product> {A, B, C, D, A, B, A}, Pricing, 13.25m * Dollar
            };
            yield return new object[]
            {
                new List<Product> {C, C, C, C, C, C, C}, Pricing, 6.0m * Dollar
            };
            yield return new object[]
            {
                new List<Product> {A, B, C, D}, Pricing, 7.25m * Dollar
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}