using master_backend.Models.ModelImplementations.BlockModels;

namespace master_backend.Models.IRepository.BlockIRepositories;

public interface IBlockKeywordRepository
{
    Task<List<BlockKeyword>> GetKeywordsAsync();
    Task<BlockKeyword?> GetKeywordByIdAsync(long blockKeywordId);
    Task<BlockKeyword?> GetKeywordByNameAsync(string keyword);
    Task<BlockKeyword> CreateKeywordAsync(BlockKeyword keyword);
    Task<BlockKeyword> UpdateKeywordAsync(BlockKeyword keyword);
    Task<bool> DeleteKeywordAsync(long blockKeywordId);    
}