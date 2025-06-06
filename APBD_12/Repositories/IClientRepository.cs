using APBD_12.Models;

namespace APBD_12.Repositories;

public interface IClientRepository
{
    Task SaveChangesAsync();
    Task DeleteClientAsync(Client client);
    Task<Client?> GetClientByIdAsync(int id);
    Task AddClientAsync(Client client);
    Task<Client?> GetClientByPeselAsync(string pesel);
    Task AddClientTripAsync(ClientTrip clientTrip);
}