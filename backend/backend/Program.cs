using backend.Models;
using backend.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
DotNetEnv.Env.Load();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddEnvironmentVariables();
string? formConnectionString = builder.Configuration.GetConnectionString("Form__Connection");

builder.Services.AddDbContext<ApplicationDbContext>(opts =>
    opts.UseNpgsql(formConnectionString));


builder.Services.AddScoped<IBusinessCategoryRepository, BusinessCategoryRepository>();
//builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
//builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
//builder.Services.AddScoped<IUserRepository, UserRepository>();



var app = builder.Build();



app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));
app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();