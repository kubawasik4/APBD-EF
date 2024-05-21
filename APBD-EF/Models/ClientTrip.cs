namespace APBD_EF.Models;

public class ClientTrip
{
    public Trip Trip { get; set; }
    public Client Client { get; set; }
    public int TripId { get; set; }
    public int ClientId { get; set; }
    public DateTime RegisteredAt { get; set; }
    public DateTime? PaymentDate { get; set; }
}