using master_backend.Models.IRepository.BlockIRepositories;
using master_backend.Models.ModelImplementations.BlockModels;
using Microsoft.EntityFrameworkCore;

namespace master_backend.Models.Repository.BlockRepositories;

public class BlockKeywordLinkRepository(ApplicationDbContext context) : IBlockKeywordLinkRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<BlockKeywordLink>> GetKeywordLinksAsync()
        => await _context.BlockKeywordLinks.AsNoTracking().ToListAsync();

    public async Task<BlockKeywordLink?> GetKeywordLinkByIdAsync(long blockKeywordLinkId)
        => await _context.BlockKeywordLinks.FirstOrDefaultAsync(l => l.blockKeywordLinkId == blockKeywordLinkId);

    public async Task<BlockKeywordLink> CreateKeywordLinkAsync(BlockKeywordLink link)
    {
        _context.BlockKeywordLinks.Add(link);
        await _context.SaveChangesAsync();
        return link;
    }

    public async Task<BlockKeywordLink> UpdateKeywordLinkAsync(BlockKeywordLink link)
    {
        _context.BlockKeywordLinks.Update(link);
        await _context.SaveChangesAsync();
        return link;
    }

    public async Task<bool> DeleteKeywordLinkAsync(long blockKeywordLinkId)
    {
        var entity = await GetKeywordLinkByIdAsync(blockKeywordLinkId);
        if (entity is null) return false;

        _context.BlockKeywordLinks.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
}