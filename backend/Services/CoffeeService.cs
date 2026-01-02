
using Microsoft.EntityFrameworkCore;
using NetClinic.Api.Data;
using NetClinic.Api.Dto;

namespace backend.api.Services;

public interface ILocationService
{
    Task<IEnumerable<LocationDto>> GetAllLocationsAsync();
}

public class LocationService(LocationsDbContext context, ILogger<LocationService> logger) : ILocationService
{
    private readonly LocationsDbContext _context = context;
    private readonly ILogger<LocationService> _logger = logger;

    public async Task<IEnumerable<LocationDto>> GetAllLocationsAsync()
    {
        _logger.LogDebug("Retrieving all locations from database");

        try
        {
            var locations = await _context.Locations.ToListAsync();
            _logger.LogInformation("Successfully retrieved {Count} locations from database", locations.Count);
            return locations;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while retrieving locations from database");
            throw;
        }
    }
}