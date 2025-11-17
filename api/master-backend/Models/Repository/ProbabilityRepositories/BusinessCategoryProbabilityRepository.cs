using master_backend.Models.IRepository.ProbabilityIRepositories;
using master_backend.Models.ModelImplementations.ProbabilityModels;
using Microsoft.EntityFrameworkCore;

namespace master_backend.Models.Repository.ProbabilityRepositories;

public class BusinessCategoryProbabilityRepository(ApplicationDbContext context) : IBusinessCategoryProbabilityRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<BusinessCategoryProbability>> GetBusinessCategoryProbabilitiesAsync()
        => await _context.BusinessCategoryProbabilities
            .AsNoTracking()
            .ToListAsync();

    public async Task<BusinessCategoryProbability?> GetBusinessCategoryProbabilityByIdAsync(long businessCategoryProbabilityId)
        => await _context.BusinessCategoryProbabilities
            .FirstOrDefaultAsync(p => p.businessCategoryProbabilityId == businessCategoryProbabilityId);

    public async Task<List<BusinessCategoryProbability>> GetBusinessCategoryProbabilitiesByActionIdAsync(long businessCategoryActionId)
        => await _context.BusinessCategoryProbabilities
            .Where(p => p.businessCategoryActionId == businessCategoryActionId)
            .AsNoTracking()
            .ToListAsync();

    public async Task<List<BusinessCategoryProbability>> GetBusinessCategoryProbabilitiesByBlockIdAsync(long blockId)
        => await _context.BusinessCategoryProbabilities
            .Where(p => p.blockId == blockId)
            .AsNoTracking()
            .ToListAsync();

    public async Task<BusinessCategoryProbability> CreateBusinessCategoryProbabilityAsync(BusinessCategoryProbability businessCategoryProbability)
    {
        _context.BusinessCategoryProbabilities.Add(businessCategoryProbability);
        await _context.SaveChangesAsync();
        return businessCategoryProbability;
    }

    public async Task<BusinessCategoryProbability> UpdateBusinessCategoryProbabilityAsync(BusinessCategoryProbability businessCategoryProbability)
    {
        _context.BusinessCategoryProbabilities.Update(businessCategoryProbability);
        await _context.SaveChangesAsync();
        return businessCategoryProbability;
    }

    public async Task<bool> DeleteBusinessCategoryProbabilityAsync(long businessCategoryProbabilityId)
    {
        var entity = await GetBusinessCategoryProbabilityByIdAsync(businessCategoryProbabilityId);
        if (entity is null) return false;

        _context.BusinessCategoryProbabilities.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
}