namespace MSN.Domain.Models.Processes
{
    public interface IProcessRepository
    {
        Task<Process> Add(Process process);
        Task<IList<Process>> GetAllProcessesAsync();
        Task<Process?> GetProcessDetailAsync(int processId);
        Task<Process?> FindById(int processId);
    }
}