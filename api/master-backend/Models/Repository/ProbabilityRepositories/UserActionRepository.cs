using master_backend.Models.IRepository.ProbabilityIRepositories;
using master_backend.Models.ModelImplementations.ProbabilityModels;
using Microsoft.EntityFrameworkCore;

namespace master_backend.Models.Repository.ProbabilityRepositories;

public class UserActionRepository(ApplicationDbContext context) : IUserActionRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<UserAction>> GetUserActionsAsync()
        => await _context.UserActions
            .AsNoTracking()
            .ToListAsync();

    public async Task<UserAction?> GetUserActionByIdAsync(long userActionId)
        => await _context.UserActions
            .FirstOrDefaultAsync(a => a.userActionId == userActionId);

    public async Task<UserAction?> GetUserActionByUserIdAsync(long userId)
        => await _context.UserActions
            .FirstOrDefaultAsync(a => a.userId == userId);

    public async Task<UserAction> CreateUserActionAsync(UserAction userAction)
    {
        _context.UserActions.Add(userAction);
        await _context.SaveChangesAsync();
        return userAction;
    }

    public async Task<UserAction> UpdateUserActionAsync(UserAction userAction)
    {
        _context.UserActions.Update(userAction);
        await _context.SaveChangesAsync();
        return userAction;
    }

    public async Task<bool> DeleteUserActionAsync(long userActionId)
    {
        var entity = await GetUserActionByIdAsync(userActionId);
        if (entity is null) return false;

        _context.UserActions.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
}