using backend.FormGeneration;
using backend.FormGeneration.Data.Repositories.GeneralRepositories;
using backend.FormGeneration.DataInterface;
using backend.FormGeneration.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// MVC / Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// If your repo uses a DbContext, register it too
builder.Services.AddDbContext<AppDBContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔑 Register repositories (Scoped is the usual choice)
builder.Services.AddScoped<IBusinessRepository, BusinessRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>(); // if you use it elsewhere

var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();