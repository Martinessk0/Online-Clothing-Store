using ClothingStore.Core.Models.Color;

namespace ClothingStore.Core.Contracts
{
    public interface IColorService
    {
        Task<List<ColorDTO>> GetAllAsync();
    }
}
