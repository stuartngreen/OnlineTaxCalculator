﻿namespace OnlineTaxCalculator.Domain.Models
{
    public class TaxBracket
    {
        public decimal LowerLimit { get; set; }
        public decimal UpperLimit { get; set; }
        public decimal TaxRate { get; set; }
    }
}
