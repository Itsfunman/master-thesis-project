using backend.FormGeneration.DatabaseAccessor.Models.GeneralDataModels;
using backend.FormGeneration.DataInterface;
using Microsoft.EntityFrameworkCore;

namespace backend.FormGeneration.Data.Repositories.GeneralRepositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly AppDBContext _context;

    public DepartmentRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Department>> GetDepartmentsAsync()
        => await _context.Departments.ToListAsync();
    
    public async Task<Department?> GetDepartmentByIdAsync(long departmentId)
        => await _context.Departments
            .FirstOrDefaultAsync(d => d.DepartmentID == departmentId);
    
    public async Task<Department?> GetDepartmentByNameAsync(string departmentName)
        => await _context.Departments
            .FirstOrDefaultAsync(d => d.DepartmentName == departmentName);

    public async Task<Department> CreateDepartmentAsync(Department department)
    {
        _context.Departments.Add(department);
        await _context.SaveChangesAsync();
        return department;
    }

    public async Task<bool> UpdateDepartmentAsync(Department department)
    {
        _context.Departments.Update(department);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteDepartmentAsync(Department department)
    {
        _context.Departments.Remove(department);
        return await _context.SaveChangesAsync() > 0;
    }
}