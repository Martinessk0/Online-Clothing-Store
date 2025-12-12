namespace ClothingStore.Core.Models.Auth
{
    public class UserProfileResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? PhoneNumber { get; set; }

        public IEnumerable<string> Roles { get; set; } = Enumerable.Empty<string>();

        public DateTime CreatedAt { get; set; }

        public string? City { get; set; }
        public string? Address { get; set; }
    }
}
