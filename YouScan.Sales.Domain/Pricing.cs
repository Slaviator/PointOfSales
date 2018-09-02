using System.Collections.Generic;

namespace YouScan.Sales.Domain
{
    public class Pricing : ValueObject
    {
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return true;
        }
    }
}