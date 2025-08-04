using MSN.Domain.Interfaces;

namespace MSN.Infrastructure.Persistence
{   
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MSNDbContext _context;

        public UnitOfWork(MSNDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
