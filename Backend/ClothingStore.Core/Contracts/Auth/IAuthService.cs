using ClothingStore.Core.Models.Auth;

namespace ClothingStore.Core.Contracts.Auth
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(RegisterRequest request);
        Task<AuthResponse> LoginAsync(LoginRequest request);

        Task<UserProfileResponse> GetProfileAsync(string userId);
        Task<UserProfileResponse> UpdateProfileAsync(string userId, UpdateUserProfileRequest request);

        Task ConfirmEmailAsync(string userId, string token);
    }
}
