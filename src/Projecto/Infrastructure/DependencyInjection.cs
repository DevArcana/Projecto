using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projecto.Infrastructure.Auth;
using Projecto.Infrastructure.Interfaces;
using Projecto.Infrastructure.Persistance;
using Projecto.Infrastructure.Services;

namespace Projecto.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(Startup));
            services.AddPersistance(configuration);

            services.AddScoped<UserContext>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}