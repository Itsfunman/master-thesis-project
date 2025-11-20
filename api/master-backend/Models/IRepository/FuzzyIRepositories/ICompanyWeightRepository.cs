using master_backend.Models.ModelImplementations.FuzzyModels;

namespace master_backend.Models.IRepository.FuzzyIRepositories;

public interface ICompanyWeightRepository
{
    Task<List<CompanyWeight>> GetCompanyWeightsAsync();
    Task<CompanyWeight?> GetCompanyWeightByIdAsync(long companyWeightId);
    Task<CompanyWeight> CreateCompanyWeightAsync(CompanyWeight companyWeight);
    Task<CompanyWeight> UpdateCompanyWeightAsync(CompanyWeight companyWeight);
    Task<bool> DeleteCompanyWeightAsync(long companyWeightId);
}