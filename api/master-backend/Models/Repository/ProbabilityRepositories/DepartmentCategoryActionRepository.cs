using master_backend.Models.IRepository.ProbabilityIRepositories;
using master_backend.Models.ModelImplementations.ProbabilityModels;
using Microsoft.EntityFrameworkCore;

namespace master_backend.Models.Repository.ProbabilityRepositories;

public class DepartmentCategoryActionRepository(ApplicationDbContext context) : IDepartmentCategoryActionRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<DepartmentCategoryAction>> GetDepartmentCategoryActionsAsync()
        => await _context.DepartmentCategoryActions
            .AsNoTracking()
            .ToListAsync();

    public async Task<DepartmentCategoryAction?> GetDepartmentCategoryActionByIdAsync(long departmentCategoryActionId)
        => await _context.DepartmentCategoryActions
            .FirstOrDefaultAsync(a => a.departmentCategoryActionId == departmentCategoryActionId);

    public async Task<List<DepartmentCategoryAction>> GetDepartmentCategoryActionsByDepartmentCategoryIdAsync(long departmentCategoryId)
        => await _context.DepartmentCategoryActions
            .Where(a => a.departmentCategoryId == departmentCategoryId)
            .AsNoTracking()
            .ToListAsync();

    public async Task<DepartmentCategoryAction> CreateDepartmentCategoryActionAsync(DepartmentCategoryAction departmentCategoryAction)
    {
        _context.DepartmentCategoryActions.Add(departmentCategoryAction);
        await _context.SaveChangesAsync();
        return departmentCategoryAction;
    }

    public async Task<DepartmentCategoryAction> UpdateDepartmentCategoryActionAsync(DepartmentCategoryAction departmentCategoryAction)
    {
        _context.DepartmentCategoryActions.Update(departmentCategoryAction);
        await _context.SaveChangesAsync();
        return departmentCategoryAction;
    }

    public async Task<bool> DeleteDepartmentCategoryActionAsync(long departmentCategoryActionId)
    {
        var entity = await _context.DepartmentCategoryActions
            .FirstOrDefaultAsync(a => a.departmentCategoryActionId == departmentCategoryActionId);

        if (entity is null) return false;

        _context.DepartmentCategoryActions.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
}