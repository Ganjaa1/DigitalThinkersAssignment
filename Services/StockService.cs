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

        public Dictionary<int, int> Checkout(CheckoutData checkoutData, int totalInserted)
        {
            Dictionary<string, int> currentStock = (Dictionary<string, int>)memoryCache.Get(memoryAddress) ?? new();

            foreach (var kvp in checkoutData.Inserted)
            {
                if (currentStock.ContainsKey(kvp.Key))
                {
                    currentStock[kvp.Key] -= kvp.Value;
                    if (currentStock[kvp.Key] < 0)
                    {
                        throw new StockException("Not enough items in stock");
                    }
                }
                else
                {
                    //return BadRequest(new { error = "Item not available in stock" });
                    throw new StockException("Item not available in stock");
                }
            }

            int change = totalInserted - checkoutData.Price;
            var changeDict = new Dictionary<int, int>();
            foreach (var kvp in currentStock)
            {
                int numChange = change / Convert.ToInt32(kvp.Key);
                if (numChange > 0)
                {
                    changeDict.Add(Convert.ToInt32(kvp.Key), numChange);
                    change -= Convert.ToInt32(kvp.Key) * numChange;
                }
            }

            return changeDict;
        }

    }
}
