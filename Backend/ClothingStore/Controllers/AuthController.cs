using ClothingStore.Core.Contracts.Auth;
using ClothingStore.Core.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ClothingStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _authService.RegisterAsync(request);
                return Ok(result); // връщаме AuthResponse с токена
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Register failed for {Email}", request.Email);
                return BadRequest(new { message = ex.Message });
            }
        }

        //Правим login post за да не качваме паролата в url-а
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _authService.LoginAsync(request);
                return Ok(result); // връщаме AuthResponse с токена
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Login failed for {Email}", request.Email);
                return Unauthorized(new { message = ex.Message });
            }
        }

        private string? GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        [HttpGet("profile")]
        [Authorize]
        public async Task<ActionResult<UserProfileResponse>> GetProfile()
        {
            var userId = GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            var profile = await _authService.GetProfileAsync(userId);
            return Ok(profile);
        }

        [HttpPut("profile")]
        [Authorize]
        public async Task<ActionResult<UserProfileResponse>> UpdateProfile([FromBody] UpdateUserProfileRequest request)
        {
            var userId = GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            var profile = await _authService.UpdateProfileAsync(userId, request);
            return Ok(profile);
        }

        [HttpGet("confirm-email")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string userId, [FromQuery] string token)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token))
            {
                return BadRequest(new { message = "Невалиден линк за потвърждение." });
            }

            try
            {
                await _authService.ConfirmEmailAsync(userId, token);
                return Ok(new { message = "Имейлът е потвърден успешно." });
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Email confirmation failed for {UserId}", userId);
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpGet("2fa/setup")]
        [Authorize]
        public async Task<ActionResult<TwoFactorSetupResponse>> GetTwoFactorSetup()
        {
            var userId = GetUserId();
            if (userId == null) return Unauthorized();

            var setup = await _authService.GetTwoFactorSetupAsync(userId);
            return Ok(setup);
        }

        [HttpPost("2fa/enable")]
        [Authorize]
        public async Task<ActionResult<TwoFactorEnableResponse>> EnableTwoFactor([FromBody] TwoFactorEnableRequest request)
        {
            var userId = GetUserId();
            if (userId == null) return Unauthorized();

            var result = await _authService.EnableTwoFactorAsync(userId, request);
            return Ok(result);
        }

        [HttpPost("2fa/disable")]
        [Authorize]
        public async Task<IActionResult> DisableTwoFactor()
        {
            var userId = GetUserId();
            if (userId == null) return Unauthorized();

            await _authService.DisableTwoFactorAsync(userId);
            return Ok(new { message = "2FA disabled." });
        }


        [HttpPost("forgot-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // За сигурност винаги връщаме 200, дори при невалиден имейл.
            try
            {
                await _authService.RequestPasswordResetAsync(request.Email);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Error requesting password reset for {Email}", request.Email);
            }

            return Ok(new
            {
                message = "Ако този имейл съществува в системата, изпратихме линк за смяна на паролата."
            });
        }

        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _authService.ResetPasswordAsync(request);
                return Ok(new
                {
                    message = "Паролата е сменена успешно. Вече можеш да влезеш с новата парола."
                });
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Reset password failed for {UserId}", request.UserId);
                return BadRequest(new { message = ex.Message });
            }
        }




    }
}
