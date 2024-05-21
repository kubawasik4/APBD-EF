using System.ComponentModel.DataAnnotations;

namespace APBD_EF.DTOS;

public class ClientsDTO
{
    public int IdClient { get; set; }
    public string Name { get; set; }
    public string Pesel { get; set; }
    public IEnumerable<TripDTO> Trips { get; set; }
}
public class TripDTO
{
    public int IdTrip { get; set; }
    public string Name { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public IEnumerable<ClientsDTO> Clients { get; set; }
}

public class CreateClientDTO
{
    [Required] public string Name { get; set; }
    [Required] public string Pesel { get; set; }
}

public class CreateTripDTO
{
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime DateFrom { get; set; }
    [Required]
    public DateTime DateTo { get; set; }
}