using master_backend.Models.IRepository;
using master_backend.Models.IRepository.GeneralIRepositories;
using master_backend.Models.ModelImplementations.GeneralModels;
using Microsoft.EntityFrameworkCore;

namespace master_backend.Models.Repository.GeneralRepositories;

public class DepartmentCategoryRepository(ApplicationDbContext context) : IDepartmentCategoryRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<DepartmentCategory>> GetDepartmentsAsync()
        => await _context.Departments.AsNoTracking().ToListAsync();

    public async Task<DepartmentCategory?> GetDepartmentByIdAsync(long departmentCategoryId)
        => await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentCategoryID == departmentCategoryId);

    public async Task<DepartmentCategory?> GetDepartmentByNameAsync(string departmentCategoryName)
        => await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentCategoryName == departmentCategoryName);

    public async Task<DepartmentCategory> CreateDepartmentAsync(DepartmentCategory departmentCategory)
    {
        _context.Departments.Add(departmentCategory);
        await _context.SaveChangesAsync();
        return departmentCategory;
    }

    public async Task<DepartmentCategory> UpdateDepartmentAsync(DepartmentCategory departmentCategory)
    {
        _context.Departments.Update(departmentCategory);
        await _context.SaveChangesAsync();
        return departmentCategory;
    }

    public async Task<bool> DeleteDepartmentAsync(long departmentCategoryId)
    {
        var department = await GetDepartmentByIdAsync(departmentCategoryId);
        if (department is null) return false;

        _context.Departments.Remove(department);
        return await _context.SaveChangesAsync() > 0;
    }
}