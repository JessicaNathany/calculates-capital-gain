using CalculatesCapitalGain.Dtos;
using CalculatesCapitalGain.Entity;

namespace CalculatesCapitalGain.Services
{
    public static class OperationOrderService
    {
        public static async Task<List<TaxDto>> CalculateTaxesAsync(IList<OrderDto> orders)
        {
            var wallet = new OrderProcesser();
            var taxes = new List<TaxDto>();

            foreach (var order in orders)
            {
                Taxation tax;

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

        private static TaxDto UpdateTaxe(Taxation tax)
        {
            return new TaxDto(tax.TaxValue);
        }
    }
}
