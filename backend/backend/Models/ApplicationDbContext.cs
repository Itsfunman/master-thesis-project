using backend.FormGeneration.DatabaseAccessor.Models.GeneralDataModels;

namespace backend.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Business> Businesses { get; set; }
}