using DirectoryService.Application;
using DirectoryService.Application.Locations.Database;
using DirectoryService.Infrastructure.Postgres.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DirectoryService.Infrastructure.Postgres;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddPostgresInfrastructure(
        this IServiceCollection services, IConfiguration configuration, ILoggerFactory loggerFactory)
    {
        services.AddDbContextPool<DirectoryServiceDbContext>(options =>
        {
            string connectionString = configuration.GetConnectionString(Constants.DATABASE)
                                      ?? throw new InvalidOperationException(
                                          $"Connection string '{Constants.DATABASE}' not found.");
            string environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") 
                                  ?? Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") 
                                  ?? "Production";

            options.UseNpgsql(connectionString);
            
            if (environment == "Development")
            {
                options.EnableSensitiveDataLogging().EnableDetailedErrors();
            }
            
            options.UseLoggerFactory(loggerFactory);
        });
        
        services.AddScoped<ILocationRepository, LocationsRepository>();
        
        return services;
    }
}