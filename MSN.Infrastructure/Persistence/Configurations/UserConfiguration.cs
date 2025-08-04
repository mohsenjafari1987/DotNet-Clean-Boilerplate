using MSN.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MSN.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            // Key
            builder.HasKey(u => u.Id);

            builder.HasMany(u => u.Roles)
                .WithOne(r => r.CreatedBy)
                .HasForeignKey(r => r.CreatedById);

            builder.HasMany(u => u.Locations)
                .WithOne(r => r.CreatedBy)
                .HasForeignKey(r => r.CreatedById);

            builder.HasMany(u => u.Resources)
                .WithOne(r => r.CreatedBy)
                .HasForeignKey(r => r.CreatedById);

            builder.HasMany(u => u.Processes)
                .WithOne(r => r.CreatedBy)
                .HasForeignKey(r => r.CreatedById);

            builder.HasMany(u => u.Departments)
                .WithOne(r => r.CreatedBy)
                .HasForeignKey(r => r.CreatedById);

            builder.Property(r => r.Created)
               .HasDefaultValueSql("CURRENT_TIMESTAMP");

        }
    }

}
