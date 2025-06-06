using APBD_12.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_12.Repositories;

public class TripRepository : ITripRepository
{
    private readonly TripContext _context;

    public TripRepository(TripContext context)
    {
        _context=context;
    }

    public async Task<(IEnumerable<Trip>, int)> GetTripsAsync(int strona, int wielkosc)
    {
        var strony = _context.Trips
            .Include(t => t.ClientTrips)
            .ThenInclude(ct => ct.IdClientNavigation)
            .Include(t => t.CountryTrips)
            .ThenInclude(ct => ct.IdCountryNavigation)
            .OrderByDescending(t => t.DateFrom);

        var liczba=await strony.CountAsync();
        var wycieczki=await strony.Skip((strona-1)*wielkosc).Take(wielkosc).ToListAsync();
        return(wycieczki, liczba);
    }

    public async Task<Trip?> GetTripByIdAsync(int idTrip)
    {
        return await _context.Trips.FindAsync(idTrip);
    }
}
