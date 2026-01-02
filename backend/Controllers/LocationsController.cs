using backend.api.Services;
using Microsoft.AspNetCore.Mvc;
using NetClinic.Api.Dto;

namespace NetClinic.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController(ILogger<LocationsController> logger, ILocationService LocationService) : ControllerBase
{
    private readonly ILogger<LocationsController> _logger = logger;
    private readonly ILocationService _locationService = LocationService;

    [HttpGet]
    public async Task<LocationsDto> Get()
    {
        _logger.LogInformation("Locations GET request received at {Timestamp}", DateTime.UtcNow);
        
        try
        {
            var locations = await _locationService.GetAllLocationsAsync();

      //  var locations = new List <LocationDto>();

            var locationsList = new LocationsDto
            {
                Locations = locations.ToList(),
            };
            _logger.LogInformation("Successfully retrieved {Count} veterinarians", locations.Count());
            return locationsList;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while retrieving veterinarians");
            throw;
        }
    }
}