using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Projecto.Infrastructure.Persistance
{
    public static class DependencyInjection
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(GetHerokuDbConnection() ?? configuration.GetConnectionString("Database"));
            });
            
            using var scope = services.BuildServiceProvider().CreateScope();
            var dbContext = scope.ServiceProvider.GetService<AppDbContext>();
            dbContext.Database.Migrate();
        }

        private static string? GetHerokuDbConnection()
        {
            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

            if (databaseUrl == null)
            {
                return null;
            }
            
            var databaseUri = new Uri(databaseUrl);
            var userInfo = databaseUri.UserInfo.Split(':');

            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = databaseUri.Host,
                Port = databaseUri.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = databaseUri.LocalPath.TrimStart('/')
            };

            return builder.ToString();
        }
    }
}