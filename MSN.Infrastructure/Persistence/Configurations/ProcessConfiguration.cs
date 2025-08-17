//using MSN.Domain.Models.Processes;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace MSN.Infrastructure.Persistence.Configurations
//{
//    public class ProcessConfiguration : IEntityTypeConfiguration<Process>
//    {
//        public void Configure(EntityTypeBuilder<Process> builder)
//        {
//            builder.ToTable("Processes");

//            // Key
//            builder.HasKey(u => u.Id);

//            builder.Property(u => u.Description)
//                .HasColumnType("text");

//            builder.HasOne(r => r.CreatedBy)
//                .WithMany(r => r.Processes)
//                .HasForeignKey(r => r.CreatedById);

//            builder.HasMany(r => r.Roles)
//                .WithMany(r => r.Processes);

//            builder.HasMany(r => r.Locations)
//                .WithMany(r => r.Processes);

//            builder.HasMany(r => r.Departments)
//                .WithMany(r => r.Processes);

//            builder.HasMany(r => r.Resources)
//                .WithMany(r => r.Processes);

//            builder.Property(r => r.Created)
//               .HasDefaultValueSql("CURRENT_TIMESTAMP");
//        }
//    }

//}
