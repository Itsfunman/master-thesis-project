using master_backend.Models.IRepository.ProbabilityIRepositories;
using master_backend.Models.ModelImplementations.ProbabilityModels;
using Microsoft.EntityFrameworkCore;

namespace master_backend.Models.Repository.ProbabilityRepositories;

public class CompanyActionRepository(ApplicationDbContext context) : ICompanyActionRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<CompanyAction>> GetCompanyActionsAsync()
        => await _context.CompanyActions.AsNoTracking().ToListAsync();

    public async Task<CompanyAction?> GetCompanyActionByIdAsync(long companyActionId)
        => await _context.CompanyActions
            .FirstOrDefaultAsync(ca => ca.companyActionId == companyActionId);

    public async Task<CompanyAction?> GetCompanyActionByCompanyIdAsync(long companyId)
        => await _context.CompanyActions
            .FirstOrDefaultAsync(ca => ca.companyId == companyId);

    public async Task<CompanyAction> CreateCompanyActionAsync(CompanyAction companyAction)
    {
        _context.CompanyActions.Add(companyAction);
        await _context.SaveChangesAsync();
        return companyAction;
    }

    public async Task<CompanyAction> UpdateCompanyActionAsync(CompanyAction companyAction)
    {
        _context.CompanyActions.Update(companyAction);
        await _context.SaveChangesAsync();
        return companyAction;
    }

    public async Task<bool> DeleteCompanyActionAsync(long companyActionId)
    {
        var entity = await GetCompanyActionByIdAsync(companyActionId);
        if (entity is null) return false;

        _context.CompanyActions.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
}