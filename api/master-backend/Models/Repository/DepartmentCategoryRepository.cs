using master_backend.Models.IRepository;
using Microsoft.EntityFrameworkCore;

namespace master_backend.Models.Repository;

public class DepartmentCategoryRepository(ApplicationDbContext context) : IDepartmentCategoryRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<DepartmentCategory>> GetDepartmentsAsync()
        => await _context.Departments.AsNoTracking().ToListAsync();

    public async Task<DepartmentCategory?> GetDepartmentByIdAsync(long departmentId)
        => await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentCategoryID == departmentId);

    public async Task<DepartmentCategory?> GetDepartmentByNameAsync(string departmentName)
        => await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentCategoryName == departmentName);

    public async Task<DepartmentCategory> CreateDepartmentAsync(DepartmentCategory department)
    {
        _context.Departments.Add(department);
        await _context.SaveChangesAsync();
        return department;
    }

    public async Task<bool> UpdateDepartmentAsync(DepartmentCategory department)
    {
        _context.Departments.Update(department);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteDepartmentAsync(DepartmentCategory department)
    {
        _context.Departments.Remove(department);
        return await _context.SaveChangesAsync() > 0;
    }
}