using backend.FormGeneration.DatabaseAccessor.Models.GeneralDataModels;

namespace backend.FormGeneration.DataInterface;

public interface ICompanyRepository
{
    Task<Company?> GetCompanyByIdAsync(long companyId);
    Task<Company?> GetCompanyByNameAsync(string companyName);
    
    Task<Company> CreateCompanyAsync(Company company);
    Task<bool> UpdateCompanyAsync(Company company);
    Task<bool> DeleteCompanyAsync(Company company);
}