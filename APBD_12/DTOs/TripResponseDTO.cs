namespace APBD_12.DTOs;

public class TripResponseDTO
{
    public int Numer { get; set; }
    public int Wielkosc { get; set; }
    public int Wszystkie { get; set; }
    public List<TripDTO> Trips { get; set; }
}