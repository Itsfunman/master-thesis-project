using master_backend.Models.ModelImplementations.GeneralModels;

namespace master_backend.Models.IRepository.GeneralIRepositories;

public interface IBusinessCategoryRepository
{
    Task<List<BusinessCategory>> GetBusinessesAsync();
    Task<BusinessCategory?> GetBusinessByIdAsync(long businessCategoryId);
    Task<BusinessCategory?> GetBusinessByNameAsync(string businessCategoryName);
    Task<BusinessCategory> CreateBusinessAsync(BusinessCategory businessCategory);
    Task<BusinessCategory> UpdateBusinessAsync(BusinessCategory businessCategory);
    Task<bool> DeleteBusinessAsync(long businessCategoryId);
}