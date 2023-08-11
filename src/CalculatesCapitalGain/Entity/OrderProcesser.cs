namespace CalculatesCapitalGain.Entity
{
    public class OrderProcesser
    {
        public int TotalOfStocks { get; set; }
        public decimal WeightedAverage { get; set; }
        public decimal TotalProfitOrLoss { get; set; }

        public void CalcWeightedAverageAsync(decimal unitCost, int quantityOfSharesTraded)
        {
            WeightedAverage = ((TotalOfStocks * WeightedAverage) + (unitCost * quantityOfSharesTraded)) / (TotalOfStocks + quantityOfSharesTraded);
        }

        public async Task<Taxation> BuyStockAsync(decimal unitCost, int quantityOfSharesTraded)
        {
            CalcWeightedAverageAsync(unitCost, quantityOfSharesTraded);

            TotalOfStocks += quantityOfSharesTraded;

            return new Taxation();
        }

        public async Task<decimal> CalculateProfitAsync(decimal unitCost, decimal quantity)
        {
            return (quantity * unitCost) - (quantity * WeightedAverage);
        }

        private async Task<bool> HasProfitAsync(decimal profit, decimal unitCost)
        {
            return (TotalProfitOrLoss + profit) > 0 && WeightedAverage <= unitCost;
        }

        public decimal CalculateProfit(decimal quantity, decimal unitCost)
        {
            return (quantity * unitCost) - (quantity * WeightedAverage);
        }

        public decimal CalculateTotalOperation(decimal quantity, decimal unitCost)
        {
            return unitCost * quantity;
        }

        public async Task<Taxation> SellStockAsync(decimal unitCost, int quantity)
        {
            var tax = new Taxation();

            TotalOfStocks -= quantity;

            var profit = CalculateProfit(quantity, unitCost);

            var hasProfit = await HasProfitAsync(profit, unitCost);

            if (!hasProfit)
            {
                TotalProfitOrLoss += profit;
                return tax;
            }

            var totalOperation = CalculateTotalOperation(quantity, unitCost);

            if (TotalProfitOrLoss < 0)
                profit += TotalProfitOrLoss;

            tax.CalcTax(totalOperation, profit);

            TotalProfitOrLoss += profit;
            return tax;
        }
    }
}
