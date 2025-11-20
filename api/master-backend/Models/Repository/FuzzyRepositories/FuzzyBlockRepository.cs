using master_backend.Models.IRepository.FuzzyIRepositories;
using master_backend.Models.ModelImplementations.FuzzyModels;
using Microsoft.EntityFrameworkCore;

namespace master_backend.Models.Repository.FuzzyRepositories;

public class FuzzyBlockRepository(ApplicationDbContext context) : IFuzzyBlockRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<FuzzyBlock>> GetFuzzyBlocksAsync()
        => await _context.FuzzyBlocks.AsNoTracking().ToListAsync();

    public async Task<List<FuzzyBlock>> GetFuzzyBlocksByBlockIdAsync(long blockId)
        => await _context.FuzzyBlocks
            .Where(fb => fb.blockId == blockId)
            .AsNoTracking()
            .ToListAsync();
    
    public async Task<FuzzyBlock?> GetFuzzyBlockByIdAsync(long fuzzyBlockId)
        => await _context.FuzzyBlocks.FirstOrDefaultAsync(fb => fb.fuzzyBlockId == fuzzyBlockId);

    public async Task<FuzzyBlock> CreateFuzzyBlockAsync(FuzzyBlock fuzzyBlock)
    {
        _context.FuzzyBlocks.Add(fuzzyBlock);
        await _context.SaveChangesAsync();
        return fuzzyBlock;
    }

    public async Task<FuzzyBlock> UpdateFuzzyBlockAsync(FuzzyBlock fuzzyBlock)
    {
        _context.FuzzyBlocks.Update(fuzzyBlock);
        await _context.SaveChangesAsync();
        return fuzzyBlock;
    }

    public async Task<bool> DeleteFuzzyBlockAsync(long fuzzyBlockId)
    {
        var fb = await GetFuzzyBlockByIdAsync(fuzzyBlockId);
        if (fb is null) return false;

        _context.FuzzyBlocks.Remove(fb);
        return await _context.SaveChangesAsync() > 0;
    }
}