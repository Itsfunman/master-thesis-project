using master_backend.Models.ModelImplementations.ProbabilityModels;

namespace master_backend.Models.IRepository.ProbabilityIRepositories;

public interface IUserActionRepository
{
    Task<List<UserAction>> GetUserActionsAsync();
    Task<UserAction?> GetUserActionByIdAsync(long userActionId);
    Task<UserAction?> GetUserActionByUserIdAsync(long userId);
    Task<UserAction> CreateUserActionAsync(UserAction userAction);
    Task<UserAction> UpdateUserActionAsync(UserAction userAction);
    Task<bool> DeleteUserActionAsync(long userActionId);
}