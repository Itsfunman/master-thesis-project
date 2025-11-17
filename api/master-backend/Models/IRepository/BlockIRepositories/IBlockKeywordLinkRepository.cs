using master_backend.Models.ModelImplementations.BlockModels;

namespace master_backend.Models.IRepository.BlockIRepositories;

public interface IBlockKeywordLinkRepository
{
    Task<List<BlockKeywordLink>> GetKeywordLinksAsync();
    Task<BlockKeywordLink?> GetKeywordLinkByIdAsync(long blockKeywordLinkId);
    Task<BlockKeywordLink> CreateKeywordLinkAsync(BlockKeywordLink link);
    Task<BlockKeywordLink> UpdateKeywordLinkAsync(BlockKeywordLink link);
    Task<bool> DeleteKeywordLinkAsync(long blockKeywordLinkId);
}