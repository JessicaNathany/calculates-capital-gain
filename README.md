# To calculate capital gain


## Input
- `operation` - If an operation is a sell operation (buy) or sell (sell).
- `unit-cost` - Unit price of the share in one currency to two decimal places
- `quantity` - Quantity of shares traded


## Input json
- `[{"operation":"buy","unit-cost":10.00,"quantity":10000}],`
- `[{"operation":"sell","unit-cost":20.00,"quantity":5000}],`
- `[{"operation":"buy","unit-cost":20.00,"quantity":10000}],`
- `[{"operation":"sell","unit-cost":10.00,"quantity":5000}],`

## Outpuet
- `[[{"tax": 0.00},{"tax": 0.00},{"tax": 0.00}],`
- `[[{"tax": 0.00},{"tax": 10000.00},{"tax": 0.00}],`



## Rules
- Calc Weighted Average
calcWeightedAverage = ((quantity of actions current * calc weighted average current) + (quantity of actions bought * purchase price)) / (quantity of actions current + quantity of actions bought)

- Calculate Profit
calculateProfit = (quantity * unitCost) - (quantity * weighted average)


## How to run
To run locally on the machine it is necessary to have installed the *framework of .NET Core 6.0 Runtime*. The commands needed to run are:


```bash
# Na pasta raiz do projeto
dotnet build
dotnet run --project src\CalculatesCapitalGain
```

## Attention!
To test the program by pasting the json, it cannot have line breaks. See the example below

[{ "operation": "buy", "unit-cost": 10.00, "quantity": 10000}, { "operation": "sell", "unit-cost": 20.00, "quantity": 5000 }, { "operation": "buy", "unit-cost": 20.00, "quantity": 10000 }, { "operation": "sell", "unit-cost": 10.00, "quantity": 5000}]]
