using System.ComponentModel.DataAnnotations;

namespace APBD_12.Models;

public partial class Client
{
    [Key]
    public int IdClient { get; set; }
    [Required,MaxLength(120)] 
    public string FirstName { get; set; } = null!;
    [Required,MaxLength(120)]
    public string LastName { get; set; } = null!;
    [Required,MaxLength(120)]
    public string Email { get; set; } = null!;
    [Required,MaxLength(120)]
    public string Telephone { get; set; } = null!;
    [Required,MaxLength(120)]
    public string Pesel { get; set; } = null!;

    public virtual ICollection<ClientTrip> ClientTrips { get; set; } = new List<ClientTrip>();
}