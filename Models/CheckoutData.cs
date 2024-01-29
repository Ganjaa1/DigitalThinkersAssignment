namespace DigitalThinkersAssignment.Models
{
    public class CheckoutData
    {
        public Dictionary<string, int> Inserted { get; set; }
        public int Price { get; set; }
        public CurrencyType Currency { get; set; }
    }

    public enum CurrencyType 
    {
        HUF,
        EUR
    }
}
