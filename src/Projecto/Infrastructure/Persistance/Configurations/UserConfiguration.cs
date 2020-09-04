using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projecto.Domain.Entities;

namespace Projecto.Infrastructure.Persistance.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.PrimaryEmail)
                .IsRequired()
                .HasMaxLength(256);

            builder.HasIndex(x => x.PrimaryEmail)
                .IsUnique();
            
            builder.Property(x => x.DisplayName)
                .IsRequired()
                .HasMaxLength(256)
                .HasDefaultValue("Unknown User");

            builder.HasMany<Project>().WithOne(x => x.Owner);
        }
    }
}