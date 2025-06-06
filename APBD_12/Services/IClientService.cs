namespace APBD_12.Services;

public interface IClientService
{
    Task<bool> DeleteClientAsync(int id);
}
