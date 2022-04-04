using Zeeros.Posts.Data.Repositories;
using Zeeros.Posts.Services;

namespace Zeeros.Posts.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(
            this IServiceCollection services)
        {
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            return services;
        }
    }
}
