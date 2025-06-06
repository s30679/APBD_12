using APBD_12.Repositories;

namespace APBD_12.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _repository;

    public ClientService(IClientRepository repository)
    {
        _repository=repository;
    }

    public async Task<bool> DeleteClientAsync(int id)
    {
        var client=await _repository.GetClientByIdAsync(id);
        if(client==null) 
            return false;
        if(client.ClientTrips.Any()) 
            throw new Exception("Nie usunę klienta zapisanego na wycieczki");
        await _repository.DeleteClientAsync(client);
        await _repository.SaveChangesAsync();
        return true;
    }
}
