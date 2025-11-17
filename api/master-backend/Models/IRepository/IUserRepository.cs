namespace master_backend.Models.IRepository;

public interface IUserRepository
{
    Task<List<User>> GetUsersAsync();
    Task<User?> GetUserByIdAsync(long userId);
    Task<User?> GetUserByEmailAsync(string email);
    Task<List<User>> GetUsersByCompanyIdAsync(long companyId);
    Task<List<User>> GetUsersByDepartmentCategoryIdAsync(long departmentCategoryId);
    Task<List<User>> GetUsersByBusinessCategoryIdAsync(long businessCategoryId);
    Task<User> CreateUserAsync(User user);
    Task<bool> UpdateUserAsync(User user);
    Task<bool> DeleteUserAsync(User user);
}