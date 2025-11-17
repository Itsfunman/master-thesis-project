using master_backend.Models.ModelImplementations.BlockModels;

namespace master_backend.Models.IRepository.BlockIRepositories;

public interface IBlockContextWeightRepository
{
    Task<List<BlockContextWeight>> GetContextWeightsAsync();
    Task<BlockContextWeight?> GetContextWeightByIdAsync(long blockContextWeightId);
    Task<BlockContextWeight> CreateContextWeightAsync(BlockContextWeight contextWeight);
    Task<BlockContextWeight> UpdateContextWeightAsync(BlockContextWeight contextWeight);
    Task<bool> DeleteContextWeightAsync(long blockContextWeightId);
}