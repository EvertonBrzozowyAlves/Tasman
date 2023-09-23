using System.Reflection;
using Microsoft.OpenApi.Models;

namespace Tasman.Domain.API.Configurations;

public static class Swagger
{
    public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Tasman - API",
                Description = "The Tasman API",
                TermsOfService = new Uri("https://github.com/EvertonBrzozowyAlves/Tasman"),
                Contact = new OpenApiContact
                {
                    Name = "Github Issues - Tasman project",
                    Url = new Uri("https://github.com/EvertonBrzozowyAlves/Tasman2/issues"),
                    Email = "everton.brzozowy.alves@gmail.com"
                }
            });
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });

        return services;
    }

    public static void UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}