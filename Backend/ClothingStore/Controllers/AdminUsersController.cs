using ClothingStore.Core.Contracts.Auth;
using ClothingStore.Core.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.Controllers
{
    [ApiController]
    [Route("api/admin/users")]
    [Authorize(Roles = "Admin")]
    public class AdminUsersController : ControllerBase
    {
        private readonly IAdminUserService _adminUserService;
        private readonly ILogger<AdminUsersController> _logger;

        public AdminUsersController(
            IAdminUserService adminUserService,
            ILogger<AdminUsersController> logger)
        {
            _adminUserService = adminUserService;
            _logger = logger;
        }

        // GET api/admin/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserProfileResponse>>> GetUsers()
        {
            var users = await _adminUserService.GetAllUsersAsync();
            return Ok(users);
        }

        public class UpdateUserRolesRequest
        {
            public bool IsAdmin { get; set; }
        }

        // POST api/admin/users/{id}/roles
        [HttpPost("{id}/roles")]
        public async Task<ActionResult<UserProfileResponse>> UpdateUserRoles(
            string id,
            [FromBody] UpdateUserRolesRequest request)
        {
            try
            {
                var updated = await _adminUserService.SetAdminRoleAsync(id, request.IsAdmin);
                return Ok(updated);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("User not found"))
            {
                _logger.LogWarning(ex, "User with id {UserId} not found when updating roles.", id);
                return NotFound(new { message = "User not found." });
            }
        }
    }
}
