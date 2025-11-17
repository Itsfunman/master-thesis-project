using master_backend.Models.ModelImplementations.ProbabilityModels;

namespace master_backend.Models.IRepository.ProbabilityIRepositories;

public interface IBusinessCategoryActionRepository
{
    Task<List<BusinessCategoryAction>> GetBusinessCategoryActionsAsync();
    Task<BusinessCategoryAction?> GetBusinessCategoryActionByIdAsync(long businessCategoryActionId);
    Task<List<BusinessCategoryAction>> GetBusinessCategoryActionsByBusinessCategoryIdAsync(long businessCategoryId);
    Task<BusinessCategoryAction> CreateBusinessCategoryActionAsync(BusinessCategoryAction businessCategoryAction);
    Task<BusinessCategoryAction> UpdateBusinessCategoryActionAsync(BusinessCategoryAction businessCategoryAction);
    Task<bool> DeleteBusinessCategoryActionAsync(long businessCategoryActionId);
}