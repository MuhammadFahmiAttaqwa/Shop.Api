using Shop.Application.Repository.User;
using Shop.Application.Repository.User.Impl;
using Shop.Auth.Impl;
using Shop.Auth.Interface;
using System.Runtime.CompilerServices;

namespace Shop.API.Extension
{
    public static class DIConfiguration
    {
        public static IServiceCollection DIExtension (this IServiceCollection service)
        {
            service.AddScoped<IUserRepository, UserRepository> ();
            service.AddScoped<IJwtService, JwtService>();
            service.AddScoped<IAuthService, AuthService>();

            return service;
        }
    }
}
