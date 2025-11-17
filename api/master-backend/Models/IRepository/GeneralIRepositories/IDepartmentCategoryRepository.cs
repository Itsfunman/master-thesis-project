using master_backend.Models.ModelImplementations.GeneralModels;

namespace master_backend.Models.IRepository.GeneralIRepositories;

public interface IDepartmentCategoryRepository
{
    Task<List<DepartmentCategory>> GetDepartmentsAsync();
    Task<DepartmentCategory?> GetDepartmentByIdAsync(long departmentCategoryId);
    Task<DepartmentCategory?> GetDepartmentByNameAsync(string departmentCategoryName);
    Task<DepartmentCategory> CreateDepartmentAsync(DepartmentCategory departmentCategory);
    Task<DepartmentCategory> UpdateDepartmentAsync(DepartmentCategory departmentCategory);
    Task<bool> DeleteDepartmentAsync(long departmentCategoryId);
}