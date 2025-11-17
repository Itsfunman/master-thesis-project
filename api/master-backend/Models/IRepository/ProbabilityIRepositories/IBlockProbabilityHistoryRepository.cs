using master_backend.Models.ModelImplementations.ProbabilityModels;

namespace master_backend.Models.IRepository.ProbabilityIRepositories;

public interface IBlockProbabilityHistoryRepository
{
    Task<List<BlockProbabilityHistory>> GetBlockProbabilityHistoriesAsync();
    Task<BlockProbabilityHistory?> GetBlockProbabilityHistoryByIdAsync(long id);
    Task<BlockProbabilityHistory> CreateBlockProbabilityHistoryAsync(BlockProbabilityHistory entity);
    Task<BlockProbabilityHistory> UpdateBlockProbabilityHistoryAsync(BlockProbabilityHistory entity);
    Task<bool> DeleteBlockProbabilityHistoryAsync(long id);
}