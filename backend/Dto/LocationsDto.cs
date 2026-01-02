namespace NetClinic.Api.Dto;

public class LocationsDto
{
    public List<LocationDto> Locations { get; set; } = new();
}

public class LocationDto
{
    public int Id { get; set; }
    public string AddressLine { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty; 
    public float Latitude { get; set; }
    public float Longitude { get; set; }
}