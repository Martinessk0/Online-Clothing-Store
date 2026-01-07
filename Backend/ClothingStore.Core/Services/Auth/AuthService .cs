using ClothingStore.Core.Contracts;
using ClothingStore.Core.Contracts.Auth;
using ClothingStore.Core.Models.Auth;
using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Identity;

namespace ClothingStore.Core.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly JwtSettings _jwtSettings;
        private readonly IEmailService _emailService;

        public AuthService(
            UserManager<ApplicationUser> userManager,
              IConfiguration configuration,
              IEmailService emailService,
              IOptions<JwtSettings> jwtOptions)
        {
            _userManager = userManager;
            _configuration = configuration;
            _emailService = emailService;
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

            var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var tokenBytes = Encoding.UTF8.GetBytes(emailToken);

            var encodedToken = WebEncoders.Base64UrlEncode(tokenBytes);

            var frontendBaseUrl = _configuration["Frontend:BaseUrl"] ?? "http://localhost:4200";
            var confirmationUrl =
                $"{frontendBaseUrl.TrimEnd('/')}/confirm-email?userId={user.Id}&token={encodedToken}";


            var subject = "Потвърждение на регистрация в Clothing Store";
            var body =
                $"Здравей, {user.FirstName ?? "потребител"}!\n\n" +
                "За да активираш профила си, отвори следния линк:\n" +
                confirmationUrl + "\n\n" +
                "Ако не си създавал акаунт, игнорирай този имейл.";

            await _emailService.SendAsync(user.Email!, subject, body);

            return await GenerateTokenAsync(user);
        }


        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new InvalidOperationException("Invalid credentials.");

            if (!user.EmailConfirmed)
                throw new InvalidOperationException("Email is not confirmed.");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isPasswordValid)
                throw new InvalidOperationException("Invalid credentials.");

            if (user.TwoFactorEnabled)
            {
                if (!string.IsNullOrWhiteSpace(request.RecoveryCode))
                {
                    var recovery = request.RecoveryCode.Replace(" ", "");
                    var redeemed = await _userManager.RedeemTwoFactorRecoveryCodeAsync(user, recovery);
                    if (!redeemed.Succeeded)
                        throw new InvalidOperationException("Invalid recovery code.");

                    return await GenerateTokenAsync(user);
                }

                if (string.IsNullOrWhiteSpace(request.TwoFactorCode))
                {
                    return new AuthResponse
                    {
                        RequiresTwoFactor = true,
                        Token = string.Empty,
                        ExpiresAtUtc = DateTime.UtcNow
                    };
                }

                var code = request.TwoFactorCode.Replace(" ", "").Replace("-", "");
                var valid2fa = await _userManager.VerifyTwoFactorTokenAsync(
                    user,
                    TokenOptions.DefaultAuthenticatorProvider,
                    code
                );

                if (!valid2fa)
                    throw new InvalidOperationException("Invalid two-factor code.");
            }

            return await GenerateTokenAsync(user);
        }


        public async Task ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId)
                ?? throw new InvalidOperationException("User not found.");

            byte[] tokenBytes;

            try
            {
                tokenBytes = WebEncoders.Base64UrlDecode(token);
            }
            catch
            {
                throw new InvalidOperationException("Invalid token.");
            }

            var normalToken = Encoding.UTF8.GetString(tokenBytes);

            var result = await _userManager.ConfirmEmailAsync(user, normalToken);

            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException(errors);
            }
        }



        private async Task<AuthResponse> GenerateTokenAsync(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("Name", user.UserName ?? string.Empty),
                new Claim("Email", user.Email ?? string.Empty)
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            claims.Add(new Claim("roles", string.Join(",", roles)));

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
                Address = user.Address,
                EmailConfirmed = user.EmailConfirmed,
                TwoFactorEnabled = user.TwoFactorEnabled
            };
        }

        public async Task<UserProfileResponse> UpdateProfileAsync(string userId, UpdateUserProfileRequest request)
        {
            var user = await _userManager.FindByIdAsync(userId)
                ?? throw new InvalidOperationException("User not found.");

            if (request.FirstName != null)
                user.FirstName = request.FirstName.Trim();

            if (request.LastName != null)
                user.LastName = request.LastName.Trim();

            if (request.City != null)
            {
                var city = request.City.Trim();
                user.City = city == string.Empty ? null : city;
            }

            if (request.Address != null)
            {
                var address = request.Address.Trim();
                user.Address = address == string.Empty ? null : address;
            }

            if (request.PhoneNumber != null)
            {
                var phone = request.PhoneNumber.Trim();
                user.PhoneNumber = phone == string.Empty ? null : phone;
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


        public async Task<TwoFactorSetupResponse> GetTwoFactorSetupAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId)
                ?? throw new InvalidOperationException("User not found.");

            if (!user.EmailConfirmed)
                throw new InvalidOperationException("Email is not confirmed.");

            var key = await _userManager.GetAuthenticatorKeyAsync(user);
            if (string.IsNullOrWhiteSpace(key))
            {
                await _userManager.ResetAuthenticatorKeyAsync(user);
                key = await _userManager.GetAuthenticatorKeyAsync(user);
            }

            var email = user.Email ?? user.UserName ?? "user";
            var issuer = "ClothingStore";

            return new TwoFactorSetupResponse
            {
                IsTwoFactorEnabled = user.TwoFactorEnabled,
                SharedKey = FormatKey(key!),
                AuthenticatorUri = GenerateOtpAuthUri(issuer, email, key!)
            };
        }

        public async Task<TwoFactorEnableResponse> EnableTwoFactorAsync(string userId, TwoFactorEnableRequest request)
        {
            var user = await _userManager.FindByIdAsync(userId)
                ?? throw new InvalidOperationException("User not found.");

            var code = request.Code.Replace(" ", "").Replace("-", "");
            var isValid = await _userManager.VerifyTwoFactorTokenAsync(
                user,
                TokenOptions.DefaultAuthenticatorProvider,
                code
            );

            if (!isValid)
                throw new InvalidOperationException("Invalid two-factor code.");

            var enableResult = await _userManager.SetTwoFactorEnabledAsync(user, true);
            if (!enableResult.Succeeded)
                throw new InvalidOperationException("Could not enable two-factor authentication.");

            var recoveryCodes = await _userManager.GenerateNewTwoFactorRecoveryCodesAsync(user, 10);

            return new TwoFactorEnableResponse
            {
                RecoveryCodes = recoveryCodes
            };
        }

        public async Task DisableTwoFactorAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId)
                ?? throw new InvalidOperationException("User not found.");

            var disableResult = await _userManager.SetTwoFactorEnabledAsync(user, false);
            if (!disableResult.Succeeded)
                throw new InvalidOperationException("Could not disable two-factor authentication.");
        }

        private static string FormatKey(string unformattedKey)
        {
            var result = new System.Text.StringBuilder();
            for (var i = 0; i + 4 <= unformattedKey.Length; i += 4)
            {
                result.Append(unformattedKey.Substring(i, 4)).Append(' ');
            }
            if (unformattedKey.Length % 4 != 0)
                result.Append(unformattedKey.Substring(unformattedKey.Length - unformattedKey.Length % 4));

            return result.ToString().Trim().ToLowerInvariant();
        }

        private static string GenerateOtpAuthUri(string issuer, string email, string unformattedKey)
        {
            return $"otpauth://totp/{UrlEncoder.Default.Encode(issuer)}:{UrlEncoder.Default.Encode(email)}" +
                   $"?secret={unformattedKey}&issuer={UrlEncoder.Default.Encode(issuer)}&digits=6";
        }

    }
}
