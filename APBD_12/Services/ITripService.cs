using APBD_12.DTOs;

namespace APBD_12.Services;

public interface ITripService
{
    Task<TripResponseDTO> GetTripsAsync(int strona, int wielkosc);
    Task<bool> AddClientToTripAsync(int id, ClientTripDTO DTO);
}
