using master_backend.Models.ModelImplementations.GeneralModels;

namespace master_backend.Models.IRepository.GeneralIRepositories;

public interface ICompanyRepository
{
    Task<List<Company>> GetCompaniesAsync();
    Task<Company?> GetCompanyByIdAsync(long companyId);
    Task<Company?> GetCompanyByNameAsync(string companyName);
    Task<Company> CreateCompanyAsync(Company company);
    Task<Company> UpdateCompanyAsync(Company company);
    Task<bool> DeleteCompanyAsync(long companyId);
}