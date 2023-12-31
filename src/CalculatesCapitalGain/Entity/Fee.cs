﻿namespace CalculatesCapitalGain.Entity
{
    public class Fee
    {
        public const decimal MAX_TAX_INCOME = 20000;
        public const decimal TAX = 0.2M; 
        public decimal TaxValue { get; set; }

        public void CalcTax(decimal totalOperation, decimal profit)
        {
            TaxValue = 0;

            if (totalOperation > Fee.MAX_TAX_INCOME)
            {
                TaxValue = profit * TAX;
            }
        }
    }
}
