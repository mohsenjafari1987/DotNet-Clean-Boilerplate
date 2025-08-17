using Microsoft.EntityFrameworkCore;

namespace MSN.Infrastructure.Persistence
{
    public class MSNDbContext : DbContext
    {
        public MSNDbContext(DbContextOptions<MSNDbContext> options) : base(options) { }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MSNDbContext).Assembly);
        }
    }
}
