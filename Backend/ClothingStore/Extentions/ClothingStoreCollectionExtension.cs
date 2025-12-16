using ClothingStore.Core.Contracts;
using ClothingStore.Core.Contracts.Auth;
using ClothingStore.Core.Services;
using ClothingStore.Core.Services.Auth;
using ClothingStore.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ClothingStoreCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAdminUserService, AdminUserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IColorService, ColorService>();

            return services;
        }
    }
}
