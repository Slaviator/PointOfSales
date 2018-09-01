using System.Collections;
using System.Collections.Generic;

namespace YouScan.Sales.Domain.UnitTests
{
    //Scan these items in this order: ABCDABA; Verify the total price is $13.25.
    //Scan these items in this order: CCCCCCC; Verify the total price is $6.00.
    //Scan these items in this order: ABCD; Verify the total price is $7.25
    //A $1.25 each or 3 for $3.00
    //B $4.25
    //C $1.00 or $5 for a six pack
    //D $0.75
    public class MinimalInputData : IEnumerable<object[]>
    {
        public Pricing Pricing { get; }
        public Product A { get; }
        public Product B { get; }
        public Product C { get; }
        public Product D { get; }

        public MinimalInputData()
        {
            Pricing = new Pricing();
            A = new Product(new ProductCode("A"));
            B = new Product(new ProductCode("B"));
            C = new Product(new ProductCode("C"));
            D = new Product(new ProductCode("D"));
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new List<Product> {A, B, C, D, A, B, A}, Pricing, new TotalPrice(13.25m)
            };
            yield return new object[]
            {
                new List<Product> {C, C, C, C, C, C, C}, Pricing, new TotalPrice(6.0m)
            };
            yield return new object[]
            {
                new List<Product> {A, B, C, D}, Pricing, new TotalPrice(7.25m)
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}