using OnlineTaxCalculator.Domain.Models;
using System.Collections.Generic;

namespace OnlineTaxCalculator.Domain.Interfaces
{
    public interface ITaxBracketRepository
    {
        IDictionary<int, IEnumerable<TaxBracket>> FindAll();
    }
}
