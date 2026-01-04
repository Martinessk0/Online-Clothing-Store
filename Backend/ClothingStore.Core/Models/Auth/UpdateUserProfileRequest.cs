using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Core.Models.Auth
{
    public class UpdateUserProfileRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? City { get; set; }
        public string? Address { get; set; }
    }
}
