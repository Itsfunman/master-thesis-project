using backend.FormGeneration.DatabaseAccessor.Models.GeneralDataModels;
using backend.Models;

namespace backend.FormGeneration.DataInterface;

public interface IBusinessRepository
{
    Task<Business?> GetBusinessByIdAsync(long id);
    Task<Business?> GetBusinessByNameAsync(string name);
    
    Task<Business> CreateBusinessAsync(Business business);
    Task<bool> UpdateBusinessAsync(Business business);
    Task<bool> DeleteBusinessAsync(Business business);
}