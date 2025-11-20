using master_backend.Models.ModelImplementations.FuzzyModels;

namespace master_backend.Models.IRepository.FuzzyIRepositories;

public interface IUserWeightRepository
{
    Task<List<UserWeight>> GetUserWeightsAsync();
    Task<UserWeight?> GetUserWeightByIdAsync(long userWeightId);
    Task<UserWeight> CreateUserWeightAsync(UserWeight userWeight);
    Task<UserWeight> UpdateUserWeightAsync(UserWeight userWeight);
    Task<bool> DeleteUserWeightAsync(long userWeightId);
}