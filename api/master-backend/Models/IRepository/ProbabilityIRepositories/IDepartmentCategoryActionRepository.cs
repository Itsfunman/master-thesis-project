using master_backend.Models.ModelImplementations.ProbabilityModels;

namespace master_backend.Models.IRepository.ProbabilityIRepositories;

public interface IDepartmentCategoryActionRepository
{
    Task<List<DepartmentCategoryAction>> GetDepartmentCategoryActionsAsync();
    Task<DepartmentCategoryAction?> GetDepartmentCategoryActionByIdAsync(long departmentCategoryActionId);
    Task<List<DepartmentCategoryAction>> GetDepartmentCategoryActionsByDepartmentCategoryIdAsync(long departmentCategoryId);
    Task<DepartmentCategoryAction> CreateDepartmentCategoryActionAsync(DepartmentCategoryAction departmentCategoryAction);
    Task<DepartmentCategoryAction> UpdateDepartmentCategoryActionAsync(DepartmentCategoryAction departmentCategoryAction);
    Task<bool> DeleteDepartmentCategoryActionAsync(long departmentCategoryActionId);
}