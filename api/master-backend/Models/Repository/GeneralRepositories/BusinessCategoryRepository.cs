using master_backend.Models.IRepository;
using master_backend.Models.IRepository.GeneralIRepositories;
using master_backend.Models.ModelImplementations.GeneralModels;
using Microsoft.EntityFrameworkCore;

namespace master_backend.Models.Repository.GeneralRepositories;

public class BusinessCategoryRepository(ApplicationDbContext context) : IBusinessCategoryRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<BusinessCategory>> GetBusinessesAsync()
        => await _context.Businesses.AsNoTracking().ToListAsync();

    public async Task<BusinessCategory?> GetBusinessByIdAsync(long businessId)
        => await _context.Businesses.FirstOrDefaultAsync(b => b.BusinessCategoryID == businessId);

    public async Task<BusinessCategory?> GetBusinessByNameAsync(string businessName)
        => await _context.Businesses.FirstOrDefaultAsync(b => b.BusinessCategoryName == businessName);

    public async Task<BusinessCategory> CreateBusinessAsync(BusinessCategory business)
    {
        _context.Businesses.Add(business);
        await _context.SaveChangesAsync();
        return business;
    }

    public async Task<BusinessCategory> UpdateBusinessAsync(BusinessCategory businessCategory)
    {
        _context.Businesses.Update(businessCategory);
        await _context.SaveChangesAsync();
        return businessCategory;
    }

    public async Task<bool> DeleteBusinessAsync(long businessCategoryId)
    {
        var bc = await GetBusinessByIdAsync(businessCategoryId);
        if (bc is null) return false;

        _context.Businesses.Remove(bc);
        return await _context.SaveChangesAsync() > 0;
    }
}