namespace MSN.Domain.Models.Departments
{
    public interface IDepartmentRepository
    {
        Task<Department?> GetByIdAsync(Guid id);
        Task AddAsync(Department student);
        Task DeleteAsync(Guid id);
    }
}