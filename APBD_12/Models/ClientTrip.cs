using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Npgsql.Replication.PgOutput.Messages;

namespace APBD_12.Models;

public partial class ClientTrip
{
    [Key,ForeignKey("IdClient"),Column(Order=0)]
    public int IdClient { get; set; }
    [Key,ForeignKey("IdTrip"),Column(Order=1)]
    public int IdTrip { get; set; }
    [Required]
    public DateTime RegisteredAt { get; set; }
    public DateTime? PaymentDate { get; set; }
    [ForeignKey(nameof(IdClient))]
    public virtual Client IdClientNavigation { get; set; } = null!;
    [ForeignKey(nameof(IdTrip))]
    public virtual Trip IdTripNavigation { get; set; } = null!;
}