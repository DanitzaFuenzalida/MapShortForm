using Microsoft.EntityFrameworkCore;
using NetClinic.Api.Dto;
namespace NetClinic.Api.Data;

public class LocationsDbContext(DbContextOptions<LocationsDbContext> options) : DbContext(options)
{
    public DbSet<LocationDto> Locations { get; set; }
}