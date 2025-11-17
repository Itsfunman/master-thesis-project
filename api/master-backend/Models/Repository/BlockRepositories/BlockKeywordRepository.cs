using master_backend.Models.IRepository.BlockIRepositories;
using master_backend.Models.ModelImplementations.BlockModels;
using Microsoft.EntityFrameworkCore;

namespace master_backend.Models.Repository.BlockRepositories;

public class BlockKeywordRepository(ApplicationDbContext context) : IBlockKeywordRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<BlockKeyword>> GetKeywordsAsync()
        => await _context.BlockKeywords.AsNoTracking().ToListAsync();

    public async Task<BlockKeyword?> GetKeywordByIdAsync(long blockKeywordId)
        => await _context.BlockKeywords.FirstOrDefaultAsync(k => k.blockKeywordId == blockKeywordId);

    public async Task<BlockKeyword?> GetKeywordByNameAsync(string keyword)
        => await _context.BlockKeywords.FirstOrDefaultAsync(k => k.keyword == keyword);

    public async Task<BlockKeyword> CreateKeywordAsync(BlockKeyword keyword)
    {
        _context.BlockKeywords.Add(keyword);
        await _context.SaveChangesAsync();
        return keyword;
    }

    public async Task<BlockKeyword> UpdateKeywordAsync(BlockKeyword keyword)
    {
        _context.BlockKeywords.Update(keyword);
        await _context.SaveChangesAsync();
        return keyword;
    }

    public async Task<bool> DeleteKeywordAsync(long blockKeywordId)
    {
        var entity = await GetKeywordByIdAsync(blockKeywordId);
        if (entity is null) return false;

        _context.BlockKeywords.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
}