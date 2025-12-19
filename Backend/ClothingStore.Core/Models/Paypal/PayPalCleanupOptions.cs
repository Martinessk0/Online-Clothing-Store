namespace ClothingStore.Core.Models.Paypal
{
    public class PayPalCleanupOptions
    {
        public int ExpireAfterMinutes { get; set; } = 10;
        public int TickSeconds { get; set; } = 120;
    }
}
