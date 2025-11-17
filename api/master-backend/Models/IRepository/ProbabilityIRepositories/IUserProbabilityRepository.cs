using master_backend.Models.ModelImplementations.ProbabilityModels;

namespace master_backend.Models.IRepository.ProbabilityIRepositories;

public interface IUserProbabilityRepository
{
    Task<List<UserProbability>> GetUserProbabilitiesAsync();
    Task<UserProbability?> GetUserProbabilityByIdAsync(long userProbabilityId);
    Task<List<UserProbability>> GetUserProbabilitiesByUserActionIdAsync(long userActionId);
    Task<List<UserProbability>> GetUserProbabilitiesByBlockIdAsync(long blockId);
    Task<UserProbability> CreateUserProbabilityAsync(UserProbability userProbability);
    Task<UserProbability> UpdateUserProbabilityAsync(UserProbability userProbability);
    Task<bool> DeleteUserProbabilityAsync(long userProbabilityId);
}