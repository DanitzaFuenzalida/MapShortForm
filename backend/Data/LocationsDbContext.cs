using Microsoft.EntityFrameworkCore;
using NetClinic.Api.Models;
namespace NetClinic.Api.Data;

public class LocationsDbContext(DbContextOptions<LocationsDbContext> options) : DbContext(options)
{
    public DbSet<Location> Locations { get; set; }

}