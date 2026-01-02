using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetClinic.Api.Models;

[Table("locations")]
public class Location
{
    [Column("id")]
    public int Id { get; set; }

    [Column("addressline")]
    [Required]
    public string AddressLine { get; set; } = string.Empty;

    [Column("city")]
    [Required]
    public string City { get; set; } = string.Empty;

    [Column("latitude")]
    public float Latitude { get; set; }

    [Column("longitude")]
    public float Longitude { get; set; }

    public Location()
    {
    }
}