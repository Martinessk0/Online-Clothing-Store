using System.Collections.Generic;
using System.Threading.Tasks;
using ClothingStore.Core.Models.Store;

namespace ClothingStore.Core.Contracts
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllAsync();
        Task<IEnumerable<OrderDto>> GetByUserAsync(string userId);
        Task<OrderDto?> GetByIdAsync(int id);

        Task<int> CreateAsync(OrderCreateDto model);

        Task UpdateAsync(int id, OrderUpdateDto model);

        Task DeleteAsync(int id);

        // 👉 това го иска контролера според грешката
        Task UpdateStatusAsync(int id, OrderStatusUpdateDto model);
    }
}
