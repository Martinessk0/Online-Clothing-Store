using ClothingStore.Core.Models.Order;

namespace ClothingStore.Core.Contracts
{
    public interface IOrderService
    {
        Task<int> CreateOrderAsync(OrderCreateDto dto, string? userId);
        Task<OrderDto?> GetOrderAsync(int id, string? userId);

        Task<IEnumerable<OrderDto>> GetUserOrdersAsync(string userId);

        Task<IEnumerable<AdminOrderListItemDto>> GetAllOrdersAsync();
        Task<bool> UpdateOrderStatusAsync(int orderId, string newStatus);
        Task<IEnumerable<string>> GetAllStatusesAsync();
    }
}
