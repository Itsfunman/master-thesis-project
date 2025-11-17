namespace master_backend.Models.IRepository;

public interface ICompanyRepository
{
    Task<List<Company>> GetCompaniesAsync();
    Task<Company?> GetCompanyByIdAsync(long companyId);
    Task<Company?> GetCompanyByNameAsync(string companyName);
    Task<Company> CreateCompanyAsync(Company company);
    Task<bool> UpdateCompanyAsync(Company company);
    Task<bool> DeleteCompanyAsync(Company company);
}