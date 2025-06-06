using Microsoft.EntityFrameworkCore;

namespace APBD_12.Models;

public partial class TripContext : DbContext
{
    public TripContext() { }
    public TripContext(DbContextOptions<TripContext> options) : base(options) { }
    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<Trip> Trips { get; set; }
    public virtual DbSet<ClientTrip> ClientTrips { get; set; }
    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<CountryTrip> CountryTrips { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(120);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(120);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(120);
            entity.Property(e => e.Telephone).IsRequired().HasMaxLength(120);
            entity.Property(e => e.Pesel).IsRequired().HasMaxLength(120);
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.IdTrip);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(120);
            entity.Property(e => e.Description).IsRequired().HasMaxLength(120);
            entity.Property(e => e.DateFrom).IsRequired();
            entity.Property(e => e.DateTo).IsRequired();
            entity.Property(e => e.MaxPeople).IsRequired();
        });
        
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.IdCountry);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(120);
        });
        
        modelBuilder.Entity<ClientTrip>(entity =>
        {
            entity.HasKey(e => new { e.IdClient, e.IdTrip });
            entity.HasOne(d => d.IdClientNavigation)
                .WithMany(p => p.ClientTrips)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdTripNavigation)
                .WithMany(p => p.ClientTrips)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });
        
        modelBuilder.Entity<CountryTrip>(entity =>
        {
            entity.HasKey(e => new { e.IdCountry, e.IdTrip });
            entity.HasOne(d => d.IdCountryNavigation)
                .WithMany(p => p.CountryTrips)
                .HasForeignKey(d => d.IdCountry)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdTripNavigation)
                .WithMany(p => p.CountryTrips)
                .HasForeignKey(d => d.IdTrip)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });
    }
}