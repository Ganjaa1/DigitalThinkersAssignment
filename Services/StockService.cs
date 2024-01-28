namespace DigitalThinkersAssignment.Services
{
    public class StockService : IStockService
    {
        Dictionary<string, int> CurrentStock = new();
        public Dictionary<string, int> Checkout(Dictionary<string, int> currencies)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, int> GetCurrentStock()
        {
            throw new NotImplementedException();
        }

        public void UpdateStock(Dictionary<string, int> currencies)
        {
            throw new NotImplementedException();
        }
    }
}
