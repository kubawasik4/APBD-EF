namespace APBD_EF.Models;

public class Trip
{ 
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public ICollection<ClientTrip> ClientTrips { get; set; }
}