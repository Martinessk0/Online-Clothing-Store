using ClothingStore.Core.Models.Contact;

namespace ClothingStore.Core.Contracts
{
    public interface IEmailService
    {
        Task SendContactEmailAsync(ContactRequest request);
    }
}
