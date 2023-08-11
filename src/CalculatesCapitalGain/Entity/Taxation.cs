namespace CalculatesCapitalGain.Entity
{
    public class Taxation
    {
        public const decimal MAX_TAX_INCOME = 20000;
        public const decimal TAX = 0.2M; 
        public decimal TaxValue { get; set; }

        public void CalcTax(decimal totalOperation, decimal profit)
        {
            TaxValue = 0;

            if (totalOperation > Taxation.MAX_TAX_INCOME)
            {
                TaxValue = profit * TAX;
            }
        }
    }
}
