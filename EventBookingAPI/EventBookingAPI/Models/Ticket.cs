namespace EventBookingAPI.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string SeatNumber { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Status { get; set; } = "available";
    }
}
