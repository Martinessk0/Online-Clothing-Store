using ClothingStore.Core.Contracts.Auth;
using ClothingStore.Core.Models.Auth;
using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Core.Services.Auth
{
    public class AdminUserService : IAdminUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminUserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IEnumerable<UserProfileResponse>> GetAllUsersAsync()
        {
            var users = _userManager.Users.ToList();
            var result = new List<UserProfileResponse>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);

                result.Add(new UserProfileResponse
                {
                    Id = user.Id,
                    Email = user.Email ?? string.Empty,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Roles = roles,
                    CreatedAt = user.CreatedAt,
                    City = user.City,
                    Address = user.Address
                });
            }

            return result;
        }

        public async Task<UserProfileResponse> SetAdminRoleAsync(string userId, bool isAdmin)
        {
            var user = await _userManager.FindByIdAsync(userId)
                ?? throw new InvalidOperationException("User not found.");

            // базовата роля – всеки трябва да е User
            if (!await _userManager.IsInRoleAsync(user, "User"))
            {
                await _userManager.AddToRoleAsync(user, "User");
            }

            var currentlyAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            if (isAdmin && !currentlyAdmin)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            else if (!isAdmin && currentlyAdmin)
            {
                await _userManager.RemoveFromRoleAsync(user, "Admin");
            }

            var roles = await _userManager.GetRolesAsync(user);

            return new UserProfileResponse
            {
                Id = user.Id,
                Email = user.Email ?? string.Empty,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Roles = roles,
                CreatedAt = user.CreatedAt,
                City = user.City,
                Address = user.Address
            };
        }
    }
}
