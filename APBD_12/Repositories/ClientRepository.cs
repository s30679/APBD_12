using APBD_12.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_12.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly TripContext _context;

    public ClientRepository(TripContext context)
    {
        _context=context;
    }

    public async Task<Client?> GetClientByIdAsync(int id)
    {
        return await _context.Clients
            .Include(c => c.ClientTrips)
            .FirstOrDefaultAsync(c => c.IdClient==id);
    }

    public async Task AddClientAsync(Client client)
    {
        await _context.Clients.AddAsync(client);
    }

    public async Task<Client?> GetClientByPeselAsync(string pesel)
    {
        return await _context.Clients.FirstOrDefaultAsync(c => c.Pesel==pesel);
    }

    public async Task DeleteClientAsync(Client client)
    {
        _context.Clients.Remove(client);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task AddClientTripAsync(ClientTrip clientTrip)
    {
        await _context.ClientTrips.AddAsync(clientTrip);
    }
}
