
using master_backend.Models.ModelImplementations;
using master_backend.Models.ModelImplementations.BlockModels;
using master_backend.Models.ModelImplementations.FuzzyModels;
using master_backend.Models.ModelImplementations.GeneralModels;
using master_backend.Models.ModelImplementations.ProbabilityModels;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    // General Stuff
    public DbSet<BusinessCategory> Businesses { get; set; } = null!;
    public DbSet<DepartmentCategory> Departments { get; set; } = null!;
    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    
    // Block stuff
    public DbSet<Block> Blocks { get; set; } = null!;
    public DbSet<BlockContextWeight> BlockContextWeights { get; set; } = null!;
    public DbSet<BlockKeyword> BlockKeywords { get; set; } = null!;
    public DbSet<BlockKeywordLink> BlockKeywordLinks { get; set; } = null!;
    
    // Probability Stuff
    public DbSet<BlockProbabilityHistory> BlockProbabilityHistories { get; set; } = null!;
    public DbSet<BusinessCategoryAction> BusinessCategoryActions { get; set; } = null!;
    public DbSet<BusinessCategoryProbability> BusinessCategoryProbabilities { get; set; } = null!;
    public DbSet<CompanyAction> CompanyActions { get; set; } = null!;
    public DbSet<CompanyProbability> CompanyProbabilities { get; set; } = null!;
    public DbSet<DepartmentCategoryAction> DepartmentCategoryActions { get; set; } = null!;
    public DbSet<DepartmentCategoryProbability> DepartmentCategoryProbabilities { get; set; } = null!;
    public DbSet<UserAction> UserActions { get; set; } = null!;
    public DbSet<UserProbability> UserProbabilities { get; set; } = null!;
    
    // Fuzzy Stuff:
    public DbSet<CompanyWeight> CompanyWeights { get; set; } = null!;
    public DbSet<FuzzyBlock> FuzzyBlocks { get; set; } = null!;
    public DbSet<UserWeight> UserWeights { get; set; } = null!;
}