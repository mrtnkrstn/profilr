namespace Profilr.Core.Models
{
    public class CryptoPrice
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public string DateLastUpdated { get; set; }
    }
}
