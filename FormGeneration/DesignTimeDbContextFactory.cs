using System;
using System.IO;
using backend.FormGeneration;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDBContext>
{
    public AppDBContext CreateDbContext(string[] args)
    {
        // Load .env from repo root or project dir (adjust path if needed)
        var root = Directory.GetParent(AppContext.BaseDirectory);
        while (root != null && !File.Exists(Path.Combine(root.FullName, ".env")))
            root = root.Parent;

        if (root != null) Env.Load(Path.Combine(root.FullName, ".env"));
        else Env.TraversePath().Load(); // fallback: search upward

        var conn = Environment.GetEnvironmentVariable("FORM_DB");
        if (string.IsNullOrWhiteSpace(conn))
            throw new InvalidOperationException("FORM_DB missing for design-time. Put it in .env or export it.");

        var options = new DbContextOptionsBuilder<AppDBContext>()
            .UseNpgsql(conn)
            .Options;

        return new AppDBContext(options);
    }
}