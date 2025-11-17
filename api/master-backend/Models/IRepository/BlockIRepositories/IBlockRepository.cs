using master_backend.Models.ModelImplementations.BlockModels;

namespace master_backend.Models.IRepository.BlockIRepositories;

public interface IBlockRepository
{
    Task<List<Block>> GetBlocksAsync();
    Task<Block?> GetBlockByIdAsync(long blockId);
    Task<Block> CreateBlockAsync(Block block);
    Task<Block> UpdateBlockAsync(Block block);
    Task<bool> DeleteBlockAsync(long blockId);
}