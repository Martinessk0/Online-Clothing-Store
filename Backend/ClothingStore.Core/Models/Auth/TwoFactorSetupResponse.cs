namespace ClothingStore.Core.Models.Auth
{
    public class TwoFactorSetupResponse
    {
        public bool IsTwoFactorEnabled { get; set; }

        public string SharedKey { get; set; } = string.Empty; 
        public string AuthenticatorUri { get; set; } = string.Empty;
    }
}
