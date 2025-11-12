using master_backend.Models.IRepository;
using Microsoft.EntityFrameworkCore;

namespace master_backend.Models.Repository;

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

    public async Task<bool> UpdateBusinessAsync(BusinessCategory business)
    {
        _context.Businesses.Update(business);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteBusinessAsync(BusinessCategory business)
    {
        _context.Businesses.Remove(business);
        return await _context.SaveChangesAsync() > 0;
    }
}