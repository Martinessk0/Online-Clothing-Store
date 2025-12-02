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
    }
}
