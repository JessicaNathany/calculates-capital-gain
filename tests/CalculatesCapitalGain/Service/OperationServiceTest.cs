using CalculatesCapitalGain.Dtos;
using CalculatesCapitalGain.Entity;
using CalculatesCapitalGain.Services;
using Xunit;

namespace CalculatesCapitalGain.Tests.Service
{
    public class OperationServiceTest
    {
        [Fact]
        public async Task OperationOrderService_ShouldBe_BuyStock_Success()
        {
            var orders = GenerateObject();

            var resultTaxes = await OperationOrderService.CalculateTaxesAsync(orders);

            Assert.NotNull(resultTaxes);
            Assert.Equal(4, resultTaxes.Count);
        }

        [Fact]
        public async Task OperationOrderService_OrdersIsNullCannotCalculate_Success()
        {
            var orders = new List<FeeDto>();

            var resultTaxes = await OperationOrderService.CalculateTaxesAsync(null);
             
            Assert.Equal(resultTaxes, orders);
        }


        [Fact]
        public void ShouldBe_CalcWeightedAverageAsync_Success()
        {
            var processer = new OrderProcesser();
            processer.TotalOfStocks = 100;
            processer.WeightedAverage = 10;

            processer.CalcWeightedAverageAsync(20, 50);

            var expected = 13.333M; 
            var actual = processer.WeightedAverage;
            var tolerance = 0.001M; 

            Assert.True(Math.Abs(expected - actual) < tolerance, $"Expected {expected}, but got {actual}");
        }

        [Fact]
        public async Task ShouldBe_BuyStockAsync_Success()
        {
            var processer = new OrderProcesser();
            await processer.BuyStockAsync(20, 50);

            Assert.Equal(50, processer.TotalOfStocks);
        }

        [Fact]
        public async Task ShouldBe_SellStockAsyncWithProfit_Success()
        {
            var processer = new OrderProcesser();
            processer.TotalOfStocks = 100;
            processer.WeightedAverage = 10;
            processer.TotalProfitOrLoss = 500;

            var fee = await processer.SellStockAsync(20, 50);

            Assert.Equal(50, processer.TotalOfStocks);
            Assert.Equal(1000, processer.TotalProfitOrLoss); 
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