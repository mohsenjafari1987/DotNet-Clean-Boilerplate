using MSN.Domain.Models.Processes;
using MSN.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MSN.Infrastructure.Repositories
{
    public class ProcessRepository : IProcessRepository
    {
        public readonly MSNDbContext _MSNDbContext;        

        public ProcessRepository(MSNDbContext MSNDbContext)
        {
            _MSNDbContext = MSNDbContext;
        }

        public async Task<Process> Add(Process process)
        {
            await _MSNDbContext.Processes.AddAsync(process);
            return process;
        }

        public async Task<Process?> FindById(int processId)
        {
            return await _MSNDbContext.Processes.FirstOrDefaultAsync(r => r.Id == processId);
        }

        public async Task<IList<Process>> GetAllProcessesAsync()
        {
            return await _MSNDbContext.Processes.ToListAsync();
        }

        public async Task<Process?> GetProcessDetailAsync(int processId)
        {
            return await _MSNDbContext.Processes
                .Include(r => r.Resources)
                .Include(r => r.Locations)
                .Include(r => r.Departments)
                .Include(r => r.Roles)
                .Include(r => r.CreatedBy)
                .FirstOrDefaultAsync(r => r.Id == processId);
        }
    }
}
