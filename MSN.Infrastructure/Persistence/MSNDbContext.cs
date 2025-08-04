using MSN.Domain.Models.Departments;
using MSN.Domain.Models.Locations;
using MSN.Domain.Models.Processes;
using MSN.Domain.Models.Resources;
using MSN.Domain.Models.Roles;
using MSN.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace MSN.Infrastructure.Persistence
{
    public class MSNDbContext : DbContext
    {
        public MSNDbContext(DbContextOptions<MSNDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Resource> Resources => Set<Resource>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Process> Processes => Set<Process>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MSNDbContext).Assembly);
        }
    }
}
