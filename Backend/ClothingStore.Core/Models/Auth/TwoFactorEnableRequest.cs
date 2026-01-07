using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Core.Models.Auth
{
    public class TwoFactorEnableRequest
    {
        [Required]
        public string Code { get; set; } = string.Empty;
    }
}
