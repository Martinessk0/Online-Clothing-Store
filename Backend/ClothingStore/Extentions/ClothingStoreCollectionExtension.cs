using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ClothingStoreCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //TODO: uncomment IRepository after adding entityframework
            //services.AddScoped<IRepository, Repository>();

            return services;
        }
    }
}
