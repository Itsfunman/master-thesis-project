using backend.FormGeneration.DatabaseAccessor.Models.GeneralDataModels;

namespace backend.FormGeneration.DataInterface;

public interface IDepartmentRepository
{
    Task<Department?> GetDepartmentByIdAsync(long departmentId);
    Task<Department?> GetDepartmentByNameAsync(string name);
    
    Task<Department> CreateDepartmentAsync(Department department);
    Task<bool> UpdateDepartmentAsync(Department department);
    Task<bool> DeleteDepartmentAsync(Department department);
}