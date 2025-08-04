using MSN.Domain.Models.Roles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MSN.Infrastructure.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            // Key
            builder.HasKey(u => u.Id);

            builder.HasOne(r => r.CreatedBy)
                .WithMany(r => r.Roles)
                .HasForeignKey(r => r.CreatedById);

            builder.HasMany(r => r.Processes)
                .WithMany(r => r.Roles);

            builder.Property(r => r.Created)
               .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }

}
