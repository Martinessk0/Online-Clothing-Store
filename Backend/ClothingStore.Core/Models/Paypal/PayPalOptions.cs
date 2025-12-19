namespace ClothingStore.Core.Models.Paypal
{
    public class PayPalOptions
    {
        public string BaseUrl { get; set; } = "https://api-m.sandbox.paypal.com";
        public string ClientId { get; set; } = "";
        public string ClientSecret { get; set; } = "";
        public string Currency { get; set; } = "BGN";
    }
}
