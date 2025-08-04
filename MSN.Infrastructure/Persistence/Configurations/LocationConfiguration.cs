using MSN.Domain.Models.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MSN.Infrastructure.Persistence.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Locations");

            // Key
            builder.HasKey(u => u.Id);

            builder.HasOne(r => r.CreatedBy)
                .WithMany(r => r.Locations)
                .HasForeignKey(r => r.CreatedById);

            builder.HasMany(r => r.Processes)
                .WithMany(r => r.Locations);

            builder.Property(r => r.Created)
               .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }

}
