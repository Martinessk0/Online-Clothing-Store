namespace ClothingStore.Core.Models.Auth
{
    public class TwoFactorEnableResponse
    {
        public IEnumerable<string> RecoveryCodes { get; set; } = Enumerable.Empty<string>();
    }
}
