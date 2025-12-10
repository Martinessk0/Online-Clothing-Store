using ClothingStore.Core.Models.Auth;

namespace ClothingStore.Core.Contracts.Auth
{
    public interface IAdminUserService
    {
        Task<IEnumerable<UserProfileResponse>> GetAllUsersAsync();

        /// <summary>
        /// Задава или маха Admin роля на даден потребител.
        /// </summary>
        /// <param name="userId">Id на потребителя.</param>
        /// <param name="isAdmin">true => да бъде Admin, false => да не бъде Admin.</param>
        Task<UserProfileResponse> SetAdminRoleAsync(string userId, bool isAdmin);
    }
}
