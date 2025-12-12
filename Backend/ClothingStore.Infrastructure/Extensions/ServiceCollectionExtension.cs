using ClothingStore.Core.Contracts;
using ClothingStore.Core.Contracts.Auth;
using ClothingStore.Infrastructure;
using ClothingStore.Infrastructure.Data.Common;
using ClothingStore.Infrastructure.Services;
using ClothingStore.Infrastructure.Services.Auth;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ClothingStoreCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Repository
            services.AddScoped<IRepository, Repository>();

            // Auth
            services.AddScoped<IAuthService, AuthService>();

            // Store services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }
    }
}
