using master_backend.Models.IRepository.FuzzyIRepositories;
using master_backend.Models.ModelImplementations.FuzzyModels;
using Microsoft.EntityFrameworkCore;

namespace master_backend.Models.Repository.FuzzyRepositories;

public class CompanyWeightRepository(ApplicationDbContext context) : ICompanyWeightRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<CompanyWeight>> GetCompanyWeightsAsync()
        => await _context.CompanyWeights.AsNoTracking().ToListAsync();

    public async Task<CompanyWeight?> GetCompanyWeightByIdAsync(long companyWeightId)
        => await _context.CompanyWeights.FirstOrDefaultAsync(cw => cw.companyWeightId == companyWeightId);

    public async Task<CompanyWeight> CreateCompanyWeightAsync(CompanyWeight companyWeight)
    {
        _context.CompanyWeights.Add(companyWeight);
        await _context.SaveChangesAsync();
        return companyWeight;
    }

    public async Task<CompanyWeight> UpdateCompanyWeightAsync(CompanyWeight companyWeight)
    {
        _context.CompanyWeights.Update(companyWeight);
        await _context.SaveChangesAsync();
        return companyWeight;
    }

    public async Task<bool> DeleteCompanyWeightAsync(long companyWeightId)
    {
        var cw = await GetCompanyWeightByIdAsync(companyWeightId);
        if (cw is null) return false;

        _context.CompanyWeights.Remove(cw);
        return await _context.SaveChangesAsync() > 0;
    }
}