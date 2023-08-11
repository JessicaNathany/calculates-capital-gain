using CalculatesCapitalGain.Dtos;
using CalculatesCapitalGain.Services;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;
public class Program
{
    public static  void Main(string[] args)
    {
        Console.WriteLine(" ..:: To calculate capital gain ::..");
        Console.WriteLine();

        Console.WriteLine("Enter the json. Important to be aware of the line break.");

        string? text;

        if (!string.IsNullOrEmpty(text = Console.ReadLine()))
        {
            var orders = JsonConvert.DeserializeObject<OrderDto[]>(text!);

            var taxes = OperationOrderService.CalculateTaxesAsync(orders!).Result; 

            Console.WriteLine(JsonConvert.SerializeObject(taxes));
        }
    }
}