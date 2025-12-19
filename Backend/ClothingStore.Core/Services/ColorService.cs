using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.Color;
using ClothingStore.Infrastructure.Data.Common;
using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Core.Services
{
    public class ColorService : IColorService
    {
        private readonly IRepository repo;

        public ColorService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<List<ColorDTO>> GetAllAsync()
        {
            return await repo.AllReadonly<Color>()
                .Select(c => new ColorDTO
                {
                    Id = c.Id,
                    Code = c.Code,
                    Name = c.Name,
                    Hex = c.Hex
                })
                .ToListAsync();
        }
    }
}
