using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repos;

public class BusinessCategoryRepository : IBusinessCategoryRepository
{
    private readonly ApplicationDbContext _context;

    public BusinessCategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Business>> GetBusinessesAsync()
        => await _context.Businesses.ToListAsync();

    public async Task<Business?> GetBusinessByIdAsync(long businessId)
        => await _context.Businesses
            .FirstOrDefaultAsync(b => b.BusinessID == businessId);
    
    public async Task<Business?> GetBusinessByNameAsync(string businessName)
        => await _context.Businesses
            .FirstOrDefaultAsync(b => b.BusinessName == businessName);

    public async Task<Business> CreateBusinessAsync(Business business)
    {
        _context.Businesses.Add(business);
        await _context.SaveChangesAsync();
        return business;
    }

    public async Task<bool> UpdateBusinessAsync(Business business)
    {
        _context.Businesses.Update(business);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteBusinessAsync(Business business)
    {
        _context.Businesses.Remove(business);
        return await _context.SaveChangesAsync() > 0;
    }
}