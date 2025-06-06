using System.ComponentModel.DataAnnotations;

namespace APBD_12.Models;

public partial class Country
{
    [Key]
    public int IdCountry { get; set; }
    [Required, MaxLength(120)]
    public string Name { get; set; } = null!;
    public virtual ICollection<CountryTrip> CountryTrips { get; set; } = new List<CountryTrip>();
}