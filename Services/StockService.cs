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

        public Dictionary<string, int> Checkout(Dictionary<string, int> currencies)
        {
            throw new NotImplementedException();
        }

    }
}
