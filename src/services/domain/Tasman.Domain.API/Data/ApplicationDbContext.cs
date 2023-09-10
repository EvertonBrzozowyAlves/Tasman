using Microsoft.EntityFrameworkCore;
using Tasman.Domain.API.Data.Models;

namespace Tasman.Domain.API.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Models.Task> Tasks { get; set; }
    public DbSet<TaskType> TaskTypes { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        DefineDeleteStrategy(modelBuilder);
        DefineColumnsWithoutMaxLength(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    private static void DefineDeleteStrategy(ModelBuilder modelBuilder)
    {
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
        }
    }

    private static void DefineColumnsWithoutMaxLength(ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            var properties = entity.GetProperties().Where(p => p.ClrType == typeof(string));

            foreach (var property in properties)
            {
                if (string.IsNullOrEmpty(property.GetColumnType()) && !property.GetMaxLength().HasValue)
                {
                    property.SetColumnType("VARCHAR(500)");
                }
            }
        }
    }
}