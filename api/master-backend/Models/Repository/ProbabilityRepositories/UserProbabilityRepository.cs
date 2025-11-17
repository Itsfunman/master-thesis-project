using master_backend.Models.IRepository.ProbabilityIRepositories;
using master_backend.Models.ModelImplementations.ProbabilityModels;
using Microsoft.EntityFrameworkCore;

namespace master_backend.Models.Repository.ProbabilityRepositories;

public class UserProbabilityRepository(ApplicationDbContext context) : IUserProbabilityRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<UserProbability>> GetUserProbabilitiesAsync()
        => await _context.UserProbabilities
            .AsNoTracking()
            .ToListAsync();

    public async Task<UserProbability?> GetUserProbabilityByIdAsync(long userProbabilityId)
        => await _context.UserProbabilities
            .FirstOrDefaultAsync(p => p.userProbabilityId == userProbabilityId);

    public async Task<List<UserProbability>> GetUserProbabilitiesByUserActionIdAsync(long userActionId)
        => await _context.UserProbabilities
            .Where(p => p.userActionId == userActionId)
            .AsNoTracking()
            .ToListAsync();

    public async Task<List<UserProbability>> GetUserProbabilitiesByBlockIdAsync(long blockId)
        => await _context.UserProbabilities
            .Where(p => p.blockId == blockId)
            .AsNoTracking()
            .ToListAsync();

    public async Task<UserProbability> CreateUserProbabilityAsync(UserProbability userProbability)
    {
        _context.UserProbabilities.Add(userProbability);
        await _context.SaveChangesAsync();
        return userProbability;
    }

    public async Task<UserProbability> UpdateUserProbabilityAsync(UserProbability userProbability)
    {
        _context.UserProbabilities.Update(userProbability);
        await _context.SaveChangesAsync();
        return userProbability;
    }

    public async Task<bool> DeleteUserProbabilityAsync(long userProbabilityId)
    {
        var entity = await GetUserProbabilityByIdAsync(userProbabilityId);
        if (entity is null) return false;

        _context.UserProbabilities.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
}