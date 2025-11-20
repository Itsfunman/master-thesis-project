using master_backend.Models.ModelImplementations.FuzzyModels;

namespace master_backend.Models.IRepository.FuzzyIRepositories;

public interface IFuzzyBlockRepository
{
    Task<List<FuzzyBlock>> GetFuzzyBlocksAsync();
    Task<List<FuzzyBlock>> GetFuzzyBlocksByBlockIdAsync(long blockId);
    Task<FuzzyBlock?> GetFuzzyBlockByIdAsync(long fuzzyBlockId);
    Task<FuzzyBlock> CreateFuzzyBlockAsync(FuzzyBlock fuzzyBlock);
    Task<FuzzyBlock> UpdateFuzzyBlockAsync(FuzzyBlock fuzzyBlock);
    Task<bool> DeleteFuzzyBlockAsync(long fuzzyBlockId);
}