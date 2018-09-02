﻿using System;
using System.Collections.Generic;

namespace YouScan.Sales.Domain
{
    public class BatchPrice : ValueObject
    {
        public Money Price { get; }
        public int BatchSize { get; }

        public BatchPrice(Money price, int batchSize)
        {
            if (batchSize <= 0) throw new ArgumentOutOfRangeException(nameof(batchSize));
            Price = price ?? throw new ArgumentNullException(nameof(price));
            BatchSize = batchSize;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Price;
            yield return BatchSize;
        }
    }
}