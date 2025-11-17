using master_backend.Models.IRepository.BlockIRepositories;
using master_backend.Models.ModelImplementations.BlockModels;
using Microsoft.EntityFrameworkCore;

namespace master_backend.Models.Repository.BlockRepositories;

public class BlockContextWeightRepository(ApplicationDbContext context) : IBlockContextWeightRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<BlockContextWeight>> GetContextWeightsAsync()
        => await _context.BlockContextWeights.AsNoTracking().ToListAsync();

    public async Task<BlockContextWeight?> GetContextWeightByIdAsync(long blockContextWeightId)
        => await _context.BlockContextWeights.FirstOrDefaultAsync(cw => cw.blockContextWeightId == blockContextWeightId);

    public async Task<BlockContextWeight> CreateContextWeightAsync(BlockContextWeight contextWeight)
    {
        _context.BlockContextWeights.Add(contextWeight);
        await _context.SaveChangesAsync();
        return contextWeight;
    }

    public async Task<BlockContextWeight> UpdateContextWeightAsync(BlockContextWeight contextWeight)
    {
        _context.BlockContextWeights.Update(contextWeight);
        await _context.SaveChangesAsync();
        return contextWeight;
    }

    public async Task<bool> DeleteContextWeightAsync(long blockContextWeightId)
    {
        var entity = await GetContextWeightByIdAsync(blockContextWeightId);
        if (entity is null) return false;

        _context.BlockContextWeights.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
}