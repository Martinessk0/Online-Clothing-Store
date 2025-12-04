using Microsoft.AspNetCore.Identity;

namespace ClothingStore.Infrastructure.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string? City { get; set; }
        public string? Address { get; set; }
    }
}
