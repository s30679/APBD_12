using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_12.Models;

public partial class CountryTrip
{
    [Key,ForeignKey("IdCountry"),Column(Order = 0)]
    public int IdCountry { get; set; }
    [Key,ForeignKey("IdTrip"),Column(Order = 0)]
    public int IdTrip { get; set; }
    [ForeignKey(nameof(IdCountry))]
    public virtual Country IdCountryNavigation { get; set; } = null!;
    [ForeignKey(nameof(IdTrip))]
    public virtual Trip IdTripNavigation { get; set; } = null!;
}