using System.ComponentModel.DataAnnotations;

public class Ticket
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public string SeatNumber { get; set; }=string.Empty;

    [Range(0, double.MaxValue, ErrorMessage = "Bilet fiyatı negatif olamaz!")]
    public decimal Price { get; set; }  // Negatif değer engellendi

    public string Status { get; set; } = "available";
}
