namespace EventBookingAPI.Models
{
    public class Events
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime date { get; set; }
        public string Venue { get; set; } = string.Empty;

    }
}
