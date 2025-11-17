using master_backend.Models.IRepository.ProbabilityIRepositories;
using master_backend.Models.ModelImplementations.ProbabilityModels;
using Microsoft.EntityFrameworkCore;

namespace master_backend.Models.Repository.ProbabilityRepositories;

public class DepartmentCategoryProbabilityRepository(ApplicationDbContext context) : IDepartmentCategoryProbabilityRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<DepartmentCategoryProbability>> GetDepartmentCategoryProbabilitiesAsync()
        => await _context.DepartmentCategoryProbabilities
            .AsNoTracking()
            .ToListAsync();

    public async Task<DepartmentCategoryProbability?> GetDepartmentCategoryProbabilityByIdAsync(long departmentCategoryProbabilityId)
        => await _context.DepartmentCategoryProbabilities
            .FirstOrDefaultAsync(p => p.departmentCategoryProbabilityId == departmentCategoryProbabilityId);

    public async Task<List<DepartmentCategoryProbability>> GetDepartmentCategoryProbabilitiesByActionIdAsync(long departmentCategoryActionId)
        => await _context.DepartmentCategoryProbabilities
            .Where(p => p.departmentCategoryActionId == departmentCategoryActionId)
            .AsNoTracking()
            .ToListAsync();

    public async Task<List<DepartmentCategoryProbability>> GetDepartmentCategoryProbabilitiesByBlockIdAsync(long blockId)
        => await _context.DepartmentCategoryProbabilities
            .Where(p => p.blockId == blockId)
            .AsNoTracking()
            .ToListAsync();

    public async Task<DepartmentCategoryProbability> CreateDepartmentCategoryProbabilityAsync(DepartmentCategoryProbability departmentCategoryProbability)
    {
        _context.DepartmentCategoryProbabilities.Add(departmentCategoryProbability);
        await _context.SaveChangesAsync();
        return departmentCategoryProbability;
    }

    public async Task<DepartmentCategoryProbability> UpdateDepartmentCategoryProbabilityAsync(DepartmentCategoryProbability departmentCategoryProbability)
    {
        _context.DepartmentCategoryProbabilities.Update(departmentCategoryProbability);
        await _context.SaveChangesAsync();
        return departmentCategoryProbability;
    }

    public async Task<bool> DeleteDepartmentCategoryProbabilityAsync(long departmentCategoryProbabilityId)
    {
        var entity = await _context.DepartmentCategoryProbabilities
            .FirstOrDefaultAsync(p => p.departmentCategoryProbabilityId == departmentCategoryProbabilityId);

        if (entity is null) return false;

        _context.DepartmentCategoryProbabilities.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
}