using master_backend.Models.IRepository.BlockIRepositories;
using master_backend.Models.IRepository.FuzzyIRepositories;
using master_backend.Models.IRepository.GeneralIRepositories;
using master_backend.Models.IRepository.ProbabilityIRepositories;
using master_backend.Models.Repository.BlockRepositories;
using master_backend.Models.Repository.FuzzyRepositories;
using master_backend.Models.Repository.GeneralRepositories;
using master_backend.Models.Repository.ProbabilityRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var cs = Environment.GetEnvironmentVariable("ConnectionStrings__Form__Connection")
         ?? builder.Configuration.GetConnectionString("Form__Connection")
         ?? throw new InvalidOperationException("Connection string not found.");

// General Stuff
builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseNpgsql(cs));
builder.Services.AddScoped<IBusinessCategoryRepository, BusinessCategoryRepository>();
builder.Services.AddScoped<IDepartmentCategoryRepository, DepartmentCategoryRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Block Stuff
builder.Services.AddScoped<IBlockRepository, BlockRepository>();
builder.Services.AddScoped<IBlockContextWeightRepository, BlockContextWeightRepository>();
builder.Services.AddScoped<IBlockKeywordRepository, BlockKeywordRepository>();
builder.Services.AddScoped<IBlockKeywordLinkRepository, BlockKeywordLinkRepository>();

// Probability Stuff
builder.Services.AddScoped<IBlockProbabilityHistoryRepository, BlockProbabilityHistoryRepository>();
builder.Services.AddScoped<IBusinessCategoryActionRepository, BusinessCategoryActionRepository>();
builder.Services.AddScoped<IBusinessCategoryProbabilityRepository, BusinessCategoryProbabilityRepository>();
builder.Services.AddScoped<ICompanyActionRepository, CompanyActionRepository>();
builder.Services.AddScoped<ICompanyProbabilityRepository, CompanyProbabilityRepository>();
builder.Services.AddScoped<IDepartmentCategoryActionRepository, DepartmentCategoryActionRepository>();
builder.Services.AddScoped<IDepartmentCategoryProbabilityRepository, DepartmentCategoryProbabilityRepository>();
builder.Services.AddScoped<IUserActionRepository, UserActionRepository>();
builder.Services.AddScoped<IUserProbabilityRepository, UserProbabilityRepository>();

// Fuzzy Stuff
builder.Services.AddScoped<ICompanyWeightRepository, CompanyWeightRepository>();
builder.Services.AddScoped<IFuzzyBlockRepository, FuzzyBlockRepository>();
builder.Services.AddScoped<IUserWeightRepository, UserWeightRepository>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("General", new OpenApiInfo { Title = "General API", Version = "v1" });
    c.SwaggerDoc("Block", new OpenApiInfo { Title = "Block API", Version = "v1" });
    c.SwaggerDoc("Probability", new OpenApiInfo { Title = "Probability API", Version = "v1" });
    c.SwaggerDoc("Fuzzy", new OpenApiInfo { Title = "Fuzzy API", Version = "v1" });

    c.DocInclusionPredicate((docName, apiDesc) =>
    {
        var groupName = apiDesc.GroupName ?? "General";
        return string.Equals(groupName, docName, StringComparison.OrdinalIgnoreCase);
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/General/swagger.json", "General API v1");
        c.SwaggerEndpoint("/swagger/Block/swagger.json", "Block API v1");
        c.SwaggerEndpoint("/swagger/Probability/swagger.json", "Probability API v1");
        c.SwaggerEndpoint("/swagger/Fuzzy/swagger.json", "Fuzzy API v1");
        c.RoutePrefix = string.Empty;
    });

}
app.MapControllers();
app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

app.Run();
