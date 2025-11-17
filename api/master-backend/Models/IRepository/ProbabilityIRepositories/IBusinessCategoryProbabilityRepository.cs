using master_backend.Models.ModelImplementations.ProbabilityModels;

namespace master_backend.Models.IRepository.ProbabilityIRepositories;

public interface IBusinessCategoryProbabilityRepository
{
    Task<List<BusinessCategoryProbability>> GetBusinessCategoryProbabilitiesAsync();
    Task<BusinessCategoryProbability?> GetBusinessCategoryProbabilityByIdAsync(long businessCategoryProbabilityId);
    Task<List<BusinessCategoryProbability>> GetBusinessCategoryProbabilitiesByActionIdAsync(long businessCategoryActionId);
    Task<List<BusinessCategoryProbability>> GetBusinessCategoryProbabilitiesByBlockIdAsync(long blockId);
    Task<BusinessCategoryProbability> CreateBusinessCategoryProbabilityAsync(BusinessCategoryProbability businessCategoryProbability);
    Task<BusinessCategoryProbability> UpdateBusinessCategoryProbabilityAsync(BusinessCategoryProbability businessCategoryProbability);
    Task<bool> DeleteBusinessCategoryProbabilityAsync(long businessCategoryProbabilityId);
}