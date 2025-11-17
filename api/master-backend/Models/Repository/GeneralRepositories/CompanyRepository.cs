using master_backend.Models.IRepository;
using master_backend.Models.IRepository.GeneralIRepositories;
using master_backend.Models.ModelImplementations.GeneralModels;
using Microsoft.EntityFrameworkCore;

namespace master_backend.Models.Repository.GeneralRepositories;

public class CompanyRepository(ApplicationDbContext context) : ICompanyRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<Company>> GetCompaniesAsync()
        => await _context.Companies.AsNoTracking().ToListAsync();

    public async Task<Company?> GetCompanyByIdAsync(long companyId)
        => await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == companyId);

    public async Task<Company?> GetCompanyByNameAsync(string companyName)
        => await _context.Companies.FirstOrDefaultAsync(c => c.CompanyName == companyName);

    public async Task<Company> CreateCompanyAsync(Company company)
    {
        _context.Companies.Add(company);
        await _context.SaveChangesAsync();
        return company;
    }

    public async Task<Company> UpdateCompanyAsync(Company company)
    {
        _context.Companies.Update(company);
        await _context.SaveChangesAsync();
        return company;
    }

    public async Task<bool> DeleteCompanyAsync(long companyId)
    {
        var company = await GetCompanyByIdAsync(companyId);
        if (company is null) return false;

        _context.Companies.Remove(company);
        return await _context.SaveChangesAsync() > 0;
    }
}