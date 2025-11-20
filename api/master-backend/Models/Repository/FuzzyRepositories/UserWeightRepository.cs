using master_backend.Models.IRepository.FuzzyIRepositories;
using master_backend.Models.ModelImplementations.FuzzyModels;
using Microsoft.EntityFrameworkCore;

namespace master_backend.Models.Repository.FuzzyRepositories;

public class UserWeightRepository(ApplicationDbContext context) : IUserWeightRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<UserWeight>> GetUserWeightsAsync()
        => await _context.UserWeights.AsNoTracking().ToListAsync();

    public async Task<UserWeight?> GetUserWeightByIdAsync(long userWeightId)
        => await _context.UserWeights.FirstOrDefaultAsync(uw => uw.userWeightId == userWeightId);

    public async Task<UserWeight> CreateUserWeightAsync(UserWeight userWeight)
    {
        _context.UserWeights.Add(userWeight);
        await _context.SaveChangesAsync();
        return userWeight;
    }

    public async Task<UserWeight> UpdateUserWeightAsync(UserWeight userWeight)
    {
        _context.UserWeights.Update(userWeight);
        await _context.SaveChangesAsync();
        return userWeight;
    }

    public async Task<bool> DeleteUserWeightAsync(long userWeightId)
    {
        var uw = await GetUserWeightByIdAsync(userWeightId);
        if (uw is null) return false;

        _context.UserWeights.Remove(uw);
        return await _context.SaveChangesAsync() > 0;
    }
}