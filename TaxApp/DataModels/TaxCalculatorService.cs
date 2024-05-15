using TaxApp.ViewModels;

namespace TaxApp.DataModels
{
    public class TaxCalculatorService
    {
        private readonly List<TaxBand> _taxBands;

        public TaxCalculatorService()
        {
            // Initialize tax bands
            _taxBands = new List<TaxBand>
        {
            new TaxBand { Name = "Tax Band A", LowerLimit = 0, UpperLimit = 5000, TaxRate = 0 },
            new TaxBand { Name = "Tax Band B", LowerLimit = 5000, UpperLimit = 20000, TaxRate = 20 },
            new TaxBand { Name = "Tax Band C", LowerLimit = 20000, TaxRate = 40 }
        };
        }

        public decimal CalculateTax(decimal salary)
        {
            decimal totalTax = 0;
            foreach (var band in _taxBands)
            {
                if (salary <= band.LowerLimit)
                    continue;

                decimal taxableAmount = band.UpperLimit.HasValue && salary > band.UpperLimit.Value ?
                    band.UpperLimit.Value - band.LowerLimit :
                    salary - band.LowerLimit;

                totalTax += (taxableAmount * band.TaxRate) / 100;
            }

            return totalTax;
        }
    }
}
