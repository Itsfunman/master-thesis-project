using backend.FormGeneration.DatabaseAccessor;
using backend.FormGeneration.Data;
using backend.FormGeneration.DatabaseAccessor.Models.GeneralDataModels;
using backend.FormGeneration.DataInterface;
using Microsoft.EntityFrameworkCore;

namespace backend.FormGeneration.Data.Repositories.GeneralRepositories;

public class UserRepository : IUserRepository
{
    private readonly AppDBContext _context;

    public UserRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
        => await _context.Users.ToListAsync(); 
    
    public async Task<User?> GetUserByIdAsync(long userId)
        => await _context.Users
            .Include(u => u.Company)
            .Include(u => u.Department)
            .Include(u => u.Business)
            .FirstOrDefaultAsync(u => u.UserID == userId);

    public async Task<User?> GetUserByEmailAsync(string email)
        => await _context.Users
            .Include(u => u.Company)
            .Include(u => u.Department)
            .Include(u => u.Business)
            .FirstOrDefaultAsync(u => u.Email == email);

    public async Task<User?> GetUserByDisplayNameAsync(string displayName)
        => await _context.Users
            .FirstOrDefaultAsync(u => u.DisplayName == displayName);

    public async Task<IEnumerable<User>> GetUserByCompanyIdAsync(long companyId)
        => await _context.Users
            .Where(u => u.CompanyID == companyId)
            .ToListAsync();

    public async Task<IEnumerable<User>> GetUserByDepartmentIdAsync(long departmentId)
        => await _context.Users
            .Where(u => u.DepartmentID == departmentId)
            .ToListAsync();

    public async Task<IEnumerable<User>> GetUserByBusinessIdAsync(long businessId)
        => await _context.Users
            .Where(u => u.BusinessID == businessId)
            .ToListAsync();

    public async Task<User> CreateUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> UpdateUserAsync(User user)
    {
        _context.Users.Update(user);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteUserAsync(User user)
    {
        _context.Users.Remove(user);
        return await _context.SaveChangesAsync() > 0;
    }
}
