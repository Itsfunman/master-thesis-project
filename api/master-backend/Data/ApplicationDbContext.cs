
using master_backend.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<BusinessCategory> Businesses { get; set; } = null!;
    public DbSet<DepartmentCategory> Departments { get; set; } = null!;
    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
}