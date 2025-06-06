using APBD_12.DTOs;
using APBD_12.Models;
using APBD_12.Repositories;

namespace APBD_12.Services;

public class TripService : ITripService
{
    private readonly ITripRepository _tripRepository;
    private readonly IClientRepository _clientRepository;

    public TripService(ITripRepository tripRepository, IClientRepository clientRepository)
    {
        _tripRepository=tripRepository;
        _clientRepository=clientRepository;
    }
    
    public async Task<bool> AddClientToTripAsync(int id, ClientTripDTO DTO)
    {
        var wycieczka=await _tripRepository.GetTripByIdAsync(id);
        
        if(wycieczka==null || wycieczka.DateFrom<=DateTime.Now) 
            return false;
        if(await _clientRepository.GetClientByPeselAsync(DTO.Pesel) is not null)
            throw new Exception("Taki klient został już dodany");

        var nowyClient=new Client 
        {
            FirstName=DTO.FirstName,
            LastName=DTO.LastName,
            Email=DTO.Email,
            Telephone=DTO.Telephone,
            Pesel=DTO.Pesel
        };

        await _clientRepository.AddClientAsync(nowyClient);
        await _clientRepository.SaveChangesAsync();

        var clientDoWycieczki=new ClientTrip
        {
            IdClient=nowyClient.IdClient,
            IdTrip=id,
            RegisteredAt=DateTime.Now,
            PaymentDate=DTO.PaymentDate
        };
        await _clientRepository.AddClientTripAsync(clientDoWycieczki);
        await _clientRepository.SaveChangesAsync();
        return true;
    }

    public async Task<TripResponseDTO> GetTripsAsync(int strona, int wielkosc)
    {
        var (wycieczki, lacznie)=await _tripRepository.GetTripsAsync(strona, wielkosc);
        var strony=(int)Math.Ceiling(lacznie/(double)wielkosc);

        return new TripResponseDTO {
            Numer=strona,
            Wielkosc=wielkosc,
            Wszystkie=strony,
            Trips=wycieczki.Select(t => new TripDTO {
                Name=t.Name,
                Description=t.Description,
                DateFrom=t.DateFrom,
                DateTo=t.DateTo,
                MaxPeople=t.MaxPeople,
                Countries=t.CountryTrips.Select(ct => new CountryDTO
                {
                    Name=ct.IdCountryNavigation.Name
                }).ToList(),
                Clients=t.ClientTrips.Select(ct => new ClientDTO 
                {
                    FirstName = ct.IdClientNavigation.FirstName,
                    LastName = ct.IdClientNavigation.LastName
                }).ToList()
            }).ToList()
        };
    }
}
