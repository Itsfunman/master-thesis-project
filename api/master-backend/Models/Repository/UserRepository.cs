using master_backend.Models.IRepository;
using Microsoft.EntityFrameworkCore;

namespace master_backend.Models.Repository;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<User>> GetUsersAsync()
        => await _context.Users
            .AsNoTracking()
            .ToListAsync();

    public async Task<User?> GetUserByIdAsync(long userId)
        => await _context.Users
            .FirstOrDefaultAsync(u => u.UserId == userId);

    public async Task<User?> GetUserByEmailAsync(string email)
        => await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email);

    public async Task<List<User>> GetUsersByCompanyIdAsync(long companyId)
        => await _context.Users
            .Where(u => u.CompanyId == companyId)
            .AsNoTracking()
            .ToListAsync();

    public async Task<List<User>> GetUsersByDepartmentCategoryIdAsync(long departmentCategoryId)
        => await _context.Users
            .Where(u => u.DepartmentCategoryId == departmentCategoryId)
            .AsNoTracking()
            .ToListAsync();

    public async Task<List<User>> GetUsersByBusinessCategoryIdAsync(long businessCategoryId)
        => await _context.Users
            .Where(u => u.BusinessCategoryId == businessCategoryId)
            .AsNoTracking()
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