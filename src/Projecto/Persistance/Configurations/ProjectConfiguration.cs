using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projecto.Domain.Entities;

namespace Projecto.Persistance.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(x => x.Name)
                .IsUnique();
            
            builder.Property(x => x.Slug)
                .IsRequired()
                .HasMaxLength(100);
            
            builder.HasIndex(x => x.Slug)
                .IsUnique();
            
            builder.Property(x => x.Description)
                .IsRequired(false)
                .HasMaxLength(500);
        }
    }
}