using master_backend.Models.IRepository.BlockIRepositories;
using master_backend.Models.ModelImplementations.BlockModels;
using Microsoft.EntityFrameworkCore;

namespace master_backend.Models.Repository.BlockRepositories;

public class BlockRepository(ApplicationDbContext context) : IBlockRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<Block>> GetBlocksAsync()
        => await _context.Blocks.AsNoTracking().ToListAsync();

    public async Task<Block?> GetBlockByIdAsync(long blockId)
        => await _context.Blocks.FirstOrDefaultAsync(b => b.blockId == blockId);

    public async Task<Block> CreateBlockAsync(Block block)
    {
        _context.Blocks.Add(block);
        await _context.SaveChangesAsync();
        return block;
    }

    public async Task<Block> UpdateBlockAsync(Block block)
    {
        _context.Blocks.Update(block);
        await _context.SaveChangesAsync();
        return block;
    }

    public async Task<bool> DeleteBlockAsync(long blockId)
    {
        var entity = await GetBlockByIdAsync(blockId);
        if (entity is null) return false;

        _context.Blocks.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
}
