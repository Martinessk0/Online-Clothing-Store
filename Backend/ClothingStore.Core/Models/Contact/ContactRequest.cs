namespace ClothingStore.Core.Models.Contact
{
    public class ContactRequest
    {
        public string? Name { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;
    }
}
