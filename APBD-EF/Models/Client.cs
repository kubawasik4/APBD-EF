﻿namespace APBD_EF.Models;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Pesel { get; set; }
    public ICollection<ClientTrip> ClientTrips { get; set; } = new List<ClientTrip>();

}