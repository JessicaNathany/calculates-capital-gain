using CalculatesCapitalGain.Dtos;
using CalculatesCapitalGain.Entity;
using CalculatesCapitalGain.Services;
using Xunit;

namespace CalculatesCapitalGain.Tests
{
    public class OperationServiceTest
    {
        [Fact]
        public async Task ShouldBe_BuyStock_Success()
        {
            var orders = GenerateObject();

            var wallet = new Wallet();
            var taxes = new List<TaxDto>();

            var resultTaxes = await OperationOrderService.CalculateTaxesAsync(orders);

           
            Assert.NotNull(resultTaxes);
            //Assert.Equal(0, resultTaxes.Count() == 0)
            Assert.Equal(4, resultTaxes.Count); 
                                                
        }


        private List<OrderDto> GenerateObject()
        {
            var orders = new List<OrderDto>();

            var orderBuy = new OrderDto
            {
                Operation = "buy",
                Quantity = 10000,
                UnitCoast = 10.00M
            };

            var orderSell = new OrderDto
            {
                Operation = "sell",
                Quantity = 5000,
                UnitCoast = 20.00M
            };

            var orderBuy2 = new OrderDto
            {
                Operation = "buy",
                Quantity = 10000,
                UnitCoast = 20.00M
            };

            var orderSell2 = new OrderDto
            {
                Operation = "sell",
                Quantity = 5000,
                UnitCoast = 10.00M
            };

            orders.Add(orderBuy);
            orders.Add(orderSell);
            orders.Add(orderBuy2);
            orders.Add(orderSell2);

            return orders;
        }
    }
}