using MSN.Domain.Models.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MSN.Infrastructure.Persistence.Configurations
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.ToTable("Resources");

            // Key
            builder.HasKey(u => u.Id);

            builder.HasOne(r => r.CreatedBy)
                .WithMany(r => r.Resources)
                .HasForeignKey(r => r.CreatedById);

            builder.HasMany(r => r.Processes)
                .WithMany(r => r.Resources);

            builder.Property(r => r.Created)
               .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }

}
