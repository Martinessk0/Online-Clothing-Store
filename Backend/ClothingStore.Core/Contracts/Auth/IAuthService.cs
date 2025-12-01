using ClothingStore.Core.Models.Auth;

namespace ClothingStore.Core.Contracts.Auth
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(RegisterRequest request);
        Task<AuthResponse> LoginAsync(LoginRequest request);
    }
}
