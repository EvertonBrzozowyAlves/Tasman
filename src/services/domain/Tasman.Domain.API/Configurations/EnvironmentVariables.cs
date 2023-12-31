using System.Text;
using dotenv.net;

namespace Tasman.Domain.API.Configurations;

public static class EnvironmentVariables
{
    public static string WriteDatabaseConnectionString => "TASMAN_DOMAIN_API_WRITE_DATABASE_CONNECTION_STRING";
    public static string ReadDatabaseConnectionString => "TASMAN_DOMAIN_API_READ_DATABASE_CONNECTION_STRING";
    public static string DiscordWebhookId => "TASMAN_DOMAIN_API_DISCORD_WEBHOOK_ID";
    public static string DiscordWebhookToken => "TASMAN_DOMAIN_API_DISCORD_WEBHOOK_TOKEN";

    public static IServiceCollection AddEnvironmentVariables(this IServiceCollection services, IWebHostEnvironment environment)
    {
        try
        {
            DotEnv.Fluent()
                .WithExceptions()
                .WithEnvFiles()
                .WithTrimValues()
                .WithEncoding(Encoding.UTF8)
                .WithOverwriteExistingVars()
                .WithProbeForEnv(probeLevelsToSearch: 6)
                .Load();
        }
        catch (Exception)
        {
            if (environment.IsEnvironment("Local"))
            {
                throw new ApplicationException("Environment File (.env) not found. The application needs a .env file to run locally.\nPlease check the section Environment Variables of the README.");
            }

            // Ignored if other environments because it is using runtime environment variables
        }

        return services;
    }
}