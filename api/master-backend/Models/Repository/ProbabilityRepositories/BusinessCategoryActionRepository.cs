using master_backend.Models.IRepository.ProbabilityIRepositories;
using master_backend.Models.ModelImplementations.ProbabilityModels;
using Microsoft.EntityFrameworkCore;

namespace master_backend.Models.Repository.ProbabilityRepositories;

public class BusinessCategoryActionRepository(ApplicationDbContext context) : IBusinessCategoryActionRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<BusinessCategoryAction>> GetBusinessCategoryActionsAsync()
        => await _context.BusinessCategoryActions
            .AsNoTracking()
            .ToListAsync();

    public async Task<BusinessCategoryAction?> GetBusinessCategoryActionByIdAsync(long businessCategoryActionId)
        => await _context.BusinessCategoryActions
            .FirstOrDefaultAsync(a => a.businessCategoryActionId == businessCategoryActionId);

    public async Task<List<BusinessCategoryAction>> GetBusinessCategoryActionsByBusinessCategoryIdAsync(long businessCategoryId)
        => await _context.BusinessCategoryActions
            .Where(a => a.businessCategoryId == businessCategoryId)
            .AsNoTracking()
            .ToListAsync();

    public async Task<BusinessCategoryAction> CreateBusinessCategoryActionAsync(BusinessCategoryAction businessCategoryAction)
    {
        _context.BusinessCategoryActions.Add(businessCategoryAction);
        await _context.SaveChangesAsync();
        return businessCategoryAction;
    }

    public async Task<BusinessCategoryAction> UpdateBusinessCategoryActionAsync(BusinessCategoryAction businessCategoryAction)
    {
        _context.BusinessCategoryActions.Update(businessCategoryAction);
        await _context.SaveChangesAsync();
        return businessCategoryAction;
    }

    public async Task<bool> DeleteBusinessCategoryActionAsync(long businessCategoryActionId)
    {
        var entity = await GetBusinessCategoryActionByIdAsync(businessCategoryActionId);
        if (entity is null) return false;

        _context.BusinessCategoryActions.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
}