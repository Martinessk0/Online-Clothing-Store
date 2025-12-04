using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingStore.Infrastructure.Data.Configuration
{
    public class RoleAssignConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(SeedRoleAssign());
        }

        private List<IdentityUserRole<string>> SeedRoleAssign()
        {
            var assigns = new List<IdentityUserRole<string>>();
            var userId = "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f";
            var userRoleId = "1";
            var adminRoleId = "2";

            var assign = new IdentityUserRole<string>
            {
                UserId = userId,
                RoleId = userRoleId
            };
            assigns.Add(assign);

            assign = new IdentityUserRole<string>
            {
                UserId = userId,
                RoleId = adminRoleId
            };
            assigns.Add(assign);

            return assigns;
        }
    }
}
