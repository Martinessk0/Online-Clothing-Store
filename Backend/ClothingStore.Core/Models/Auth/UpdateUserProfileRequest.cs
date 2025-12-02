using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Core.Models.Auth
{
    public class UpdateUserProfileRequest
    {
        [Phone]
        public string? PhoneNumber { get; set; }
    }
}
