
using DigitalThinkersAssignment.Models;

namespace DigitalThinkersAssignment.Services
{
    public interface IStockService
    {
        public Dictionary<string, int> UpdateStock(Dictionary<string, int> currencies);
        public Dictionary<string,int> GetCurrentStock();
        public Dictionary<string, int> Checkout(CheckoutData checkoutData);
    }
}
