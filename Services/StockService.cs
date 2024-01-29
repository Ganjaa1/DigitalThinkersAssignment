using DigitalThinkersAssignment.Exceptions;
using DigitalThinkersAssignment.Models;
using Microsoft.Extensions.Caching.Memory;

namespace DigitalThinkersAssignment.Services
{
    public class StockService : IStockService
    {
        private const string memoryAddress = "DTASTOCK";
        private readonly IMemoryCache memoryCache;

        public StockService(IMemoryCache memoryCache) 
        {
            this.memoryCache = memoryCache;
        }

        public void UpdateStock(Dictionary<string, int> currencies)
        {
            Dictionary<string, int> currentStock = (Dictionary<string, int>)memoryCache.Get(memoryAddress) ?? new();
            foreach (var currency in currencies)
            {
                if (currentStock.TryGetValue(currency.Key, out int currentAmount))
                {
                    currentStock[currency.Key] = currentAmount + currency.Value;
                }
                else
                {
                    currentStock[currency.Key] = currency.Value;
                }
            }
            memoryCache.Set(memoryAddress, currentStock);
        }

        public Dictionary<string, int> GetCurrentStock()
        {
            return (Dictionary<string, int>)memoryCache.Get(memoryAddress);
        }

        public Dictionary<string, int> Checkout(CheckoutData checkoutData)
        {
            if (checkoutData == null) throw new StockException("Invalid purchase request. Please provide a valid request!");

            if (checkoutData.Price == null || checkoutData.Price <= 0) throw new StockException("The price entered must be a number or a non-negative number!");

            int totalInserted = checkoutData.Inserted.Sum(kvp => Convert.ToInt32(kvp.Key) * kvp.Value);
            if (totalInserted < checkoutData.Price) throw new StockException("The cash given does not cover the price!");

            Dictionary<string, int> currentStock = (Dictionary<string, int>)memoryCache.Get(memoryAddress) ?? new();

            // calc the change
            int change = totalInserted - checkoutData.Price;
            var changeDict = new Dictionary<string, int>();
            while (change != 0) 
            {
                Dictionary<string, int> availableChanges = currentStock.Where(s => Convert.ToInt32(s.Key) <= change).OrderByDescending(s => Convert.ToInt32(s.Key)).ToDictionary();
                if(availableChanges.Count == 0) throw new StockException("No change available in stock!");
                
                foreach (var stock in availableChanges)
                {
                    int numChange = change / Convert.ToInt32(stock.Key);
                    if (numChange > 0)
                    {
                        // check whether there is enough left to subtract from it
                        if (stock.Value - numChange < 0)
                        {
                            continue;
                        }
                        changeDict.Add(stock.Key, numChange);
                        change -= Convert.ToInt32(stock.Key) * numChange;
                        currentStock[stock.Key] -= numChange;
                    }
                }
            }

            // updating the stock with the inserted coins
            foreach (var insertedData in checkoutData.Inserted)
            {
                if (currentStock.ContainsKey(insertedData.Key))
                {
                    currentStock[insertedData.Key] += insertedData.Value;
                }
                else
                {
                    currentStock[insertedData.Key] = insertedData.Value;
                }
            }

            return changeDict;
        }

    }
}
