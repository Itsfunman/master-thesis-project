using backend.FormGeneration.DatabaseAccessor.Models.GeneralDataModels;
 
 namespace backend.FormGeneration.DataInterface;
 
 public interface IUserRepository
 {
     Task<User?> GetUserByIdAsync(long userId);
     Task<User?> GetUserByEmailAsync(string email);
     Task<User?> GetUserByDisplayNameAsync(string displayName);
     
     Task<IEnumerable<User>> GetUserByCompanyIdAsync(long companyId);
     Task<IEnumerable<User>> GetUserByDepartmentIdAsync(long departmentId);
     Task<IEnumerable<User>> GetUserByBusinessIdAsync(long businessId);
     
     Task<User> CreateUserAsync(User user);
     Task<bool> UpdateUserAsync(User user);
     Task<bool> DeleteUserAsync(User user);
 }