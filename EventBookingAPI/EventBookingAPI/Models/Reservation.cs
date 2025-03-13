namespace EventBookingAPI.Models
{
    public class Reservation
    {
        public int Id {get; set;}

        public int TicketId {get; set;}
        public string CustomerName {get; set;} = string.Empty;
        public DateTime ReservationDate {get; set;} = DateTime.UtcNow;
        public string Status {get; set;} = "active";
    } 
}
