using master_backend.Models.IRepository.ProbabilityIRepositories;
using master_backend.Models.ModelImplementations.ProbabilityModels;
using Microsoft.EntityFrameworkCore;

namespace master_backend.Models.Repository.ProbabilityRepositories;

public class BlockProbabilityHistoryRepository(ApplicationDbContext context)
    : IBlockProbabilityHistoryRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<BlockProbabilityHistory>> GetBlockProbabilityHistoriesAsync()
        => await _context.BlockProbabilityHistories.AsNoTracking().ToListAsync();

    public async Task<BlockProbabilityHistory?> GetBlockProbabilityHistoryByIdAsync(long id)
        => await _context.BlockProbabilityHistories
            .FirstOrDefaultAsync(p => p.blockProbabilityHistoryId == id);

    public async Task<BlockProbabilityHistory> CreateBlockProbabilityHistoryAsync(BlockProbabilityHistory entity)
    {
        _context.BlockProbabilityHistories.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<BlockProbabilityHistory> UpdateBlockProbabilityHistoryAsync(BlockProbabilityHistory entity)
    {
        _context.BlockProbabilityHistories.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteBlockProbabilityHistoryAsync(long id)
    {
        var entity = await _context.BlockProbabilityHistories.FindAsync(id);
        if (entity is null) return false;

        _context.BlockProbabilityHistories.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
}