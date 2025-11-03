using backend.FormGeneration.DatabaseAccessor.Models.GeneralDataModels;
using backend.FormGeneration.DataInterface;
using Microsoft.EntityFrameworkCore;

namespace backend.FormGeneration.Data.Repositories.GeneralRepositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly AppDBContext _context;

    public CompanyRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Company>> GetCompaniesAsync()
        => await _context.Companies.ToListAsync();
    
    public async Task<Company?> GetCompanyByIdAsync(long companyId)
        => await _context.Companies
            .FirstOrDefaultAsync(c => c.CompanyId == companyId);
    
    public async Task<Company?> GetCompanyByNameAsync(string companyName)
        => await _context.Companies
            .FirstOrDefaultAsync(c => c.CompanyName == companyName);


    public async Task<Company> CreateCompanyAsync(Company company)
    {
        _context.Companies.Add(company);
        await _context.SaveChangesAsync();
        return company;
    }

    public async Task<bool> UpdateCompanyAsync(Company company)
    {
        _context.Companies.Update(company);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteCompanyAsync(Company company)
    {
        _context.Companies.Remove(company);
        return await _context.SaveChangesAsync() > 0;
    }
}