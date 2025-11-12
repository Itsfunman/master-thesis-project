namespace master_backend.Models.IRepository;

public interface IBusinessCategoryRepository
{
    Task<List<BusinessCategory>> GetBusinessesAsync();
    Task<BusinessCategory?> GetBusinessByIdAsync(long businessCategoryId);
    Task<BusinessCategory?> GetBusinessByNameAsync(string businessCategoryName);
    Task<BusinessCategory> CreateBusinessAsync(BusinessCategory businessCategory);
    Task<bool> UpdateBusinessAsync(BusinessCategory businessCategory);
    Task<bool> DeleteBusinessAsync(BusinessCategory businessCategory);
}