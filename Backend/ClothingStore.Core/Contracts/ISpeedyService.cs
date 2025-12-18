using ClothingStore.Core.Models.Speedy;

namespace ClothingStore.Core.Contracts
{
    public interface ISpeedyService
    {
        Task<SpeedyOfficeDto?> GetOfficeByIdAsync(int officeId);
    }
}
