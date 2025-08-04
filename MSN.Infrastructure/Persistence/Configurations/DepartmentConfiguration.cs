using MSN.Domain.Models.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MSN.Infrastructure.Persistence.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");

            // Key
            builder.HasKey(u => u.Id);

            builder.HasOne(r => r.CreatedBy)
                .WithMany(r => r.Departments)
                .HasForeignKey(r => r.CreatedById);

            builder.HasMany(r => r.Processes)
                .WithMany(r => r.Departments);

            builder.Property(r => r.Created)
               .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }

}
