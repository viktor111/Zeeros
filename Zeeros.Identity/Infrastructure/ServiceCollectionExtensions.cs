using Zeeros.Identity.Data.Repositories;
using Zeeros.Identity.Service;

namespace Zeeros.Identity.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(
            this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IRegisterService, RegisterService>();

            return services;
        }
    }
}
