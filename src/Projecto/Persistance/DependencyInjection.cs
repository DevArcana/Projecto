using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Projecto.Persistance
{
    public static class DependencyInjection
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(GetConnectionString(configuration));
            });
        }

        private static string GetConnectionString(IConfiguration configuration)
        {
            // Support Heroku's environment variables
            return configuration.GetConnectionString("Database");
        }
    }
}