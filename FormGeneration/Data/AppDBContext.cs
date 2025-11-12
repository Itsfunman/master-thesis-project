using backend.FormGeneration.Data.DatabaseAccessor.Configurations.GeneralConfigurations;
using backend.FormGeneration.DatabaseAccessor.Configurators;
using backend.FormGeneration.DatabaseAccessor.Controllers.GeneralControllers;
using backend.FormGeneration.DatabaseAccessor.Models.GeneralDataModels;
using backend.Models;

namespace backend.FormGeneration;

using Microsoft.EntityFrameworkCore;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) {}    
    //Datasets for mndels
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Department> Departments { get; set; } = null!;
    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<Business>  Businesses { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DepartmentConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CompanyConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BusinessConfiguration).Assembly);
    }
    
}