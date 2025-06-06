using APBD_12.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_12.Controllers;

[ApiController]
[Route("api/clients")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpDelete("{idClient}")]
    public async Task<IActionResult> DeleteClient(int id)
    {
        try
        {
            var odp=await _clientService.DeleteClientAsync(id);
            if(!odp)
                return NotFound("Taki klient nie istnieje");
            return NoContent();
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}