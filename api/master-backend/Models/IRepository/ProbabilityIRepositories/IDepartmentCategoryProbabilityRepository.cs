using master_backend.Models.ModelImplementations.ProbabilityModels;

namespace master_backend.Models.IRepository.ProbabilityIRepositories;

public interface IDepartmentCategoryProbabilityRepository
{
    Task<List<DepartmentCategoryProbability>> GetDepartmentCategoryProbabilitiesAsync();
    Task<DepartmentCategoryProbability?> GetDepartmentCategoryProbabilityByIdAsync(long departmentCategoryProbabilityId);
    Task<List<DepartmentCategoryProbability>> GetDepartmentCategoryProbabilitiesByActionIdAsync(long departmentCategoryActionId);
    Task<List<DepartmentCategoryProbability>> GetDepartmentCategoryProbabilitiesByBlockIdAsync(long blockId);
    Task<DepartmentCategoryProbability> CreateDepartmentCategoryProbabilityAsync(DepartmentCategoryProbability departmentCategoryProbability);
    Task<DepartmentCategoryProbability> UpdateDepartmentCategoryProbabilityAsync(DepartmentCategoryProbability departmentCategoryProbability);
    Task<bool> DeleteDepartmentCategoryProbabilityAsync(long departmentCategoryProbabilityId);
}