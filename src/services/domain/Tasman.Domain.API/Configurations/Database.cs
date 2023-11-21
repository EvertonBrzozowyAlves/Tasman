using Microsoft.EntityFrameworkCore;
using Tasman.Domain.API.Data;

namespace Tasman.Domain.API.Configurations;

public static class Database
{
    public static IServiceCollection ConfigureDatabase(this IServiceCollection services)
    {
        var writeDatabaseConnectionString = Environment.GetEnvironmentVariable(EnvironmentVariables.WriteDatabaseConnectionString);
        
        //TODO: configure the read database
        var readDatabaseConnectionString = Environment.GetEnvironmentVariable(EnvironmentVariables.ReadDatabaseConnectionString);

        services.AddDbContext<WriteDbContext>(options =>
        {
            options.UseSqlServer(writeDatabaseConnectionString, assembly =>
                assembly.MigrationsAssembly(typeof(WriteDbContext).Assembly.FullName)
                        .EnableRetryOnFailure(maxRetryCount: 2, maxRetryDelay: TimeSpan.FromSeconds(2), errorNumbersToAdd: null)
                        .MigrationsHistoryTable("_AppliedMigrations"));
        });

        // services.AddEventStoreClient(clientSettings =>
        // {
        //     clientSettings.ConnectivitySettings = new EventStoreClientConnectivitySettings
        //     {
        //         // Address = new Uri("http://host.docker.internal:2113?tls=false"), Insecure = true
        //         Address = new Uri("https://localhost:2113?tls=false"), Insecure = true
        //     };
        // });
        
        return services;
    }
}