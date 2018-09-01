﻿using System;

namespace YouScan.Sales.Domain
{
    public class ProductCode
    {
        public string Code { get; }

        public ProductCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(code));
            Code = code;
        }
    }
}