using APBD_12.DTOs;
using APBD_12.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_12.Controllers;

[ApiController]
[Route("api/trips")]
public class TripController : ControllerBase
{
    private readonly ITripService _tripService;
    public TripController(ITripService tripService)
    {
        _tripService=tripService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTrips([FromQuery] int strona=1, [FromQuery] int wielkosc=10)
    {
        var odp=await _tripService.GetTripsAsync(strona, wielkosc);
        return Ok(odp);
    }

    [HttpPost("{id}/clients")]
    public async Task<IActionResult> AddClientToTrip(int id, [FromBody] ClientTripDTO DTO)
    {
        try
        {
            var odp=await _tripService.AddClientToTripAsync(id, DTO);
            if (!odp)
                return BadRequest("Nie można dokonać zapisu na wycieczkę");
            return Ok("Klient został zapisany na wyjazd");
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}