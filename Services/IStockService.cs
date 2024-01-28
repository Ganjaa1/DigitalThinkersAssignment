
namespace DigitalThinkersAssignment.Services
{
    public interface IStockService
    {
        public Dictionary<string,int> GetCurrentStock();
        public void UpdateStock(Dictionary<string, int> currencies);
        public Dictionary<string, int> Checkout(Dictionary<string, int> currencies);
    }
}
