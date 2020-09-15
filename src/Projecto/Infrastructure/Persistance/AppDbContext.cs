using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projecto.Authentication;
using Projecto.Common.Entities.Interfaces;
using Projecto.Projects;

namespace Projecto.Infrastructure.Persistance
{
    public class AppDbContext : DbContext
    {
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<User> Users => Set<User>();
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        private string ToSeparateString(IEnumerable<string> strings)
        {
            var builder = new StringBuilder();
            builder.AppendJoin(' ', strings);
            return builder.ToString();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var erroneouslyUpdated = ChangeTracker.Entries<object>()
                .Where(c => !(c.Entity is IUpdated) && c.State == EntityState.Modified)
                .Select(c => c.Metadata.Name)
                .Distinct()
                .ToList();
 
            if (erroneouslyUpdated.Any()) throw new ApplicationException($"Detected updates to entities not implementing {nameof(IUpdated)}: {ToSeparateString(erroneouslyUpdated)}");

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            foreach (var entityType in builder.Model
                .GetEntityTypes()
                .Where(entity => typeof(ICreated).IsAssignableFrom(entity.ClrType)))
            {
                var createdUtc = entityType.FindProperty(nameof(ICreated.CreatedUtc));
                createdUtc.IsNullable = false;
                createdUtc.SetColumnType("timestamp");
            }
            
            foreach (var entityType in builder.Model
                .GetEntityTypes()
                .Where(entity => typeof(IUpdated).IsAssignableFrom(entity.ClrType)))
            {
                var updatedUtc = entityType.FindProperty(nameof(IUpdated.UpdatedUtc));

                updatedUtc.IsConcurrencyToken = true;
                updatedUtc.SetColumnType("timestamp");
            }
        }
    }
}