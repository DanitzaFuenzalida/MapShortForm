namespace NetClinic.Api.Dto;

public class LocationsDto
{
    public List<LocationDto> Locations { get; set; } = new();
}

public class LocationDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
}