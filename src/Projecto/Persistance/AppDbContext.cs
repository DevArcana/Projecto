using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projecto.Domain.Entities;
using Projecto.Domain.Interfaces;

namespace Projecto.Persistance
{
    public class AppDbContext : DbContext
    {
        public DbSet<Project> Projects => Set<Project>();
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        private string ToSeparateString(IEnumerable<string> strings)
        {
            var builder = new StringBuilder();
            builder.AppendJoin(' ', strings);
            return builder.ToString();
        }

        public override int SaveChanges()
        {
            throw new InvalidOperationException();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            throw new InvalidOperationException();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new InvalidOperationException();
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
                entityType.FindProperty(nameof(ICreated.CreatedUtc)).IsNullable = false;
                entityType.FindProperty(nameof(ICreated.CreatedBy)).IsNullable = false;
            }
            
            foreach (var entityType in builder.Model
                .GetEntityTypes()
                .Where(entity => typeof(IUpdated).IsAssignableFrom(entity.ClrType)))
            {
                var prop = entityType.FindProperty(nameof(ICreated.CreatedUtc));

                prop.IsConcurrencyToken = true;
                prop.SetColumnType("datetime2");
            }
        }
    }
}