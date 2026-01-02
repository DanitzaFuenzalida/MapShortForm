
using backend.api.Services;
using Microsoft.EntityFrameworkCore;
using NetClinic.Api.Data;

namespace backend.api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configure logging
        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        builder.Logging.AddDebug();

        // Add services to the container.
        builder.Services.AddControllers();
        
        // Configure PostgreSQL - prioritize Azure connection string if available
        var connectionString = builder.Configuration.GetConnectionString("AZURE_POSTGRESQL_CONNECTIONSTRING") 
                             ?? builder.Configuration.GetConnectionString("DefaultConnection");
        
        builder.Services.AddDbContext<LocationsDbContext>(options =>
            options.UseNpgsql(connectionString));
        
        // Register custom services
        builder.Services.AddScoped<ILocationService, LocationService>();
        
        // CORS for the frontend application
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });

        var app = builder.Build();

        app.MapControllers();

        app.Run();
    }
}
