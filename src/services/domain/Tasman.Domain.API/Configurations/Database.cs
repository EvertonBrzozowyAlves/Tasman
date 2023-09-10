//using Microsoft.EntityFrameworkCore;

namespace Tasman.Domain.API.Configurations;

public static class Database
{
    public static IServiceCollection ConfigureDatabase(this IServiceCollection services)
    {
        var writeDatabaseConnectionString = Environment.GetEnvironmentVariable(EnvironmentVariables.WriteDatabaseConnectionString);
        var readDatabaseConnectionString = Environment.GetEnvironmentVariable(EnvironmentVariables.ReadDatabaseConnectionString);

        // if (string.IsNullOrWhiteSpace(connectionString))
        // {
        //     throw new ApplicationException("Undefined Database Connection String. Please check the Environment Variables.");
        // }

        // services.AddDbContext<ApplicationDbContext>(options =>
        // {
        //     options.UseSqlServer(connectionString, assembly =>
        //         assembly.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
        //                 .EnableRetryOnFailure(maxRetryCount: 2, maxRetryDelay: TimeSpan.FromSeconds(2), errorNumbersToAdd: null)
        //                 .MigrationsHistoryTable("_AppliedMigrations"));
        // });

        return services;
    }
}