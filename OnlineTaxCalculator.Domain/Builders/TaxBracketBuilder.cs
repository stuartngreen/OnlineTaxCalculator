﻿using OnlineTaxCalculator.Domain.Models;
using System.Collections.Generic;

namespace OnlineTaxCalculator.Domain.Builders
{
    class TaxBracketBuilder
    {
        protected IList<TaxBracket> _taxBrackets = new List<TaxBracket>();

        public TaxBracketBuilder AddBracket(decimal lowerLimit, decimal upperLimit, decimal taxRate)
        {
            var taxBracket = new TaxBracket
            {
                LowerLimit = lowerLimit,
                UpperLimit = upperLimit,
                TaxRate = taxRate
            };

            _taxBrackets.Add(taxBracket);

            return this;
        }

        public IList<TaxBracket> Build()
        {
            return _taxBrackets;
        }
    }
}
