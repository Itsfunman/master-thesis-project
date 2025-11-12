using master_backend.Models.IRepository;
using master_backend.Models.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var cs = Environment.GetEnvironmentVariable("ConnectionStrings__Form__Connection")
         ?? builder.Configuration.GetConnectionString("Form__Connection")
         ?? throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseNpgsql(cs));
builder.Services.AddScoped<IBusinessCategoryRepository, BusinessCategoryRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

// OPTIONAL: apply EF migrations automatically on container start
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate(); // remove if you prefer manual "dotnet ef" execution
}

app.Run();
