using ClothingStore.Core.Contracts.Auth;
using ClothingStore.Core.Models.Auth;
using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Core.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<IdentityUser> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            //SignInManager<IdentityUser> signInManager,
            IOptions<JwtSettings> jwtOptions)
        {
            _userManager = userManager;
            //_signInManager = signInManager;
            _jwtSettings = jwtOptions.Value;
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            var existing = await _userManager.FindByEmailAsync(request.Email);
            if (existing != null)
            {
                throw new InvalidOperationException("Email is already in use.");
            }

            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,

                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                City = request.City,
                Address = request.Address,
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException(errors);
            }

            await _userManager.AddToRoleAsync(user, "User");

            return await GenerateTokenAsync(user);
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new InvalidOperationException("Invalid credentials.");
            }

            var passwordValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!passwordValid)
            {
                throw new InvalidOperationException("Invalid credentials.");
            }

            return await GenerateTokenAsync(user);
        }

        private async Task<AuthResponse> GenerateTokenAsync(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName ?? string.Empty),
                new Claim(ClaimTypes.Email, user.Email ?? string.Empty)
            };

            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpireInMinutes);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.ValidIssuer,
                audience: _jwtSettings.ValidAudience,
                claims: claims,
                expires: expires,
                signingCredentials: creds);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new AuthResponse
            {
                Token = tokenString,
                ExpiresAtUtc = expires
            };
        }

        public async Task<UserProfileResponse> GetProfileAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId)
                ?? throw new InvalidOperationException("User not found.");

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

        public async Task<UserProfileResponse> UpdateProfileAsync(string userId, UpdateUserProfileRequest request)
        {
            var user = await _userManager.FindByIdAsync(userId)
                ?? throw new InvalidOperationException("User not found.");

            if (request.FirstName != null)
            {
                user.FirstName = request.FirstName;
            }

            if (request.LastName != null)
            {
                user.LastName = request.LastName;
            }

            if (request.PhoneNumber != null)
            {
                user.PhoneNumber = request.PhoneNumber;
            }

            if (request.City != null)
            {
                user.City = request.City;
            }

            if (request.Address != null)
            {
                user.Address = request.Address;
            }

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Cannot update profile: {errors}");
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
