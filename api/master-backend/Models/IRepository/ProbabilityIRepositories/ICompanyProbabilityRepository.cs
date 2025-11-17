using master_backend.Models.ModelImplementations.ProbabilityModels;

namespace master_backend.Models.IRepository.ProbabilityIRepositories;

public interface ICompanyProbabilityRepository
{
    Task<List<CompanyProbability>> GetCompanyProbabilitiesAsync();
    Task<CompanyProbability?> GetCompanyProbabilityByIdAsync(long companyProbabilityId);
    Task<List<CompanyProbability>> GetCompanyProbabilitiesByCompanyActionIdAsync(long companyActionId);
    Task<List<CompanyProbability>> GetCompanyProbabilitiesByBlockIdAsync(long blockId);
    Task<CompanyProbability> CreateCompanyProbabilityAsync(CompanyProbability companyProbability);
    Task<CompanyProbability> UpdateCompanyProbabilityAsync(CompanyProbability companyProbability);
    Task<bool> DeleteCompanyProbabilityAsync(long companyProbabilityId);
}