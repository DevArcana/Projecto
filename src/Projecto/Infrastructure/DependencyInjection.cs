using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projecto.Infrastructure.Persistance;

namespace Projecto.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddPersistance(configuration);
        }
    }
}