using master_backend.Models.ModelImplementations.ProbabilityModels;

namespace master_backend.Models.IRepository.ProbabilityIRepositories;

public interface ICompanyActionRepository
{
    Task<List<CompanyAction>> GetCompanyActionsAsync();
    Task<CompanyAction?> GetCompanyActionByIdAsync(long companyActionId);
    Task<CompanyAction?> GetCompanyActionByCompanyIdAsync(long companyId);
    Task<CompanyAction> CreateCompanyActionAsync(CompanyAction companyAction);
    Task<CompanyAction> UpdateCompanyActionAsync(CompanyAction companyAction);
    Task<bool> DeleteCompanyActionAsync(long companyActionId);
}