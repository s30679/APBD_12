using APBD_12.Models;

namespace APBD_12.Repositories;

public interface ITripRepository
{
    Task<(IEnumerable<Trip> wycieczki, int lacznie)> GetTripsAsync(int strona, int wielkosc);
    Task<Trip> GetTripByIdAsync(int id);
}