using master_backend.Models.IRepository.ProbabilityIRepositories;
using master_backend.Models.ModelImplementations.ProbabilityModels;
using Microsoft.EntityFrameworkCore;

namespace master_backend.Models.Repository.ProbabilityRepositories;

public class CompanyProbabilityRepository(ApplicationDbContext context) : ICompanyProbabilityRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<CompanyProbability>> GetCompanyProbabilitiesAsync()
        => await _context.CompanyProbabilities.AsNoTracking().ToListAsync();

    public async Task<CompanyProbability?> GetCompanyProbabilityByIdAsync(long companyProbabilityId)
        => await _context.CompanyProbabilities
            .FirstOrDefaultAsync(cp => cp.companyProbabilityId == companyProbabilityId);

    public async Task<List<CompanyProbability>> GetCompanyProbabilitiesByCompanyActionIdAsync(long companyActionId)
        => await _context.CompanyProbabilities
            .Where(cp => cp.companyActionId == companyActionId)
            .AsNoTracking()
            .ToListAsync();

    public async Task<List<CompanyProbability>> GetCompanyProbabilitiesByBlockIdAsync(long blockId)
        => await _context.CompanyProbabilities
            .Where(cp => cp.blockId == blockId)
            .AsNoTracking()
            .ToListAsync();

    public async Task<CompanyProbability> CreateCompanyProbabilityAsync(CompanyProbability companyProbability)
    {
        _context.CompanyProbabilities.Add(companyProbability);
        await _context.SaveChangesAsync();
        return companyProbability;
    }

    public async Task<CompanyProbability> UpdateCompanyProbabilityAsync(CompanyProbability companyProbability)
    {
        _context.CompanyProbabilities.Update(companyProbability);
        await _context.SaveChangesAsync();
        return companyProbability;
    }

    public async Task<bool> DeleteCompanyProbabilityAsync(long companyProbabilityId)
    {
        var entity = await GetCompanyProbabilityByIdAsync(companyProbabilityId);
        if (entity is null) return false;

        _context.CompanyProbabilities.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
}