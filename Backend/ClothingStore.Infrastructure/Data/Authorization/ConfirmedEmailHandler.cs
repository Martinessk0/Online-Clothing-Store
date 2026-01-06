using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ClothingStore.Infrastructure.Data.Authorization
{
    public class ConfirmedEmailHandler : AuthorizationHandler<ConfirmedEmailRequirement>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ConfirmedEmailHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            ConfirmedEmailRequirement requirement)
        {
            if (context.User?.Identity?.IsAuthenticated != true)
            {
                return;
            }

            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return;
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user?.EmailConfirmed == true)
            {
                context.Succeed(requirement);
            }
        }
    }
}
