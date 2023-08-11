using CalculatesCapitalGain.Dtos;
using CalculatesCapitalGain.Entity;

namespace CalculatesCapitalGain.Services
{
    public static class OperationOrderService
    {
        public static async Task<List<FeeDto>> CalculateTaxesAsync(IList<OrderDto> orders)
        {
            var wallet = new OrderProcesser();
            var taxes = new List<FeeDto>();

            if (orders is null)
                return new List<FeeDto>();

            foreach (var order in orders)
            {
                Fee tax;

                if (order.Operation == "buy") 
                {
                    tax = await wallet.BuyStockAsync(order.UnitCoast, order.Quantity);
                }
                else
                {
                    tax = await wallet.SellStockAsync(order.UnitCoast, order.Quantity);
                }

                taxes.Add(UpdateTaxe(tax));
            }

            return taxes;
        }

        private static FeeDto UpdateTaxe(Fee tax)
        {
            return new FeeDto(tax.TaxValue);
        }
    }
}
