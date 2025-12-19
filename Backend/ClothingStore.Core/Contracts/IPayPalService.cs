namespace ClothingStore.Core.Contracts
{
    public interface IPayPalService
    {
        Task<string> CreateCheckoutOrderAsync(int orderId, string? userId);
        Task<bool> CaptureCheckoutOrderAsync(int orderId, string paypalOrderId, string? userId);
    }
}
