namespace master_backend.Models.IRepository;

public interface IDepartmentCategoryRepository
{
    Task<List<DepartmentCategory>> GetDepartmentsAsync();
    Task<DepartmentCategory?> GetDepartmentByIdAsync(long departmentCategoryId);
    Task<DepartmentCategory?> GetDepartmentByNameAsync(string departmentCategoryName);
    Task<DepartmentCategory> CreateDepartmentAsync(DepartmentCategory departmentCategory);
    Task<bool> UpdateDepartmentAsync(DepartmentCategory departmentCategory);
    Task<bool> DeleteDepartmentAsync(DepartmentCategory departmentCategory);
}