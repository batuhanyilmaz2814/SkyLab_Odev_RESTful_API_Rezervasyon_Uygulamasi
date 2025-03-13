using System.ComponentModel.DataAnnotations;

namespace EventBookingAPI.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bilet ID gerekli!")]
        public int TicketId { get; set; }

        [Required(ErrorMessage = "Müşteri adı boş olamaz!")]
        [MaxLength(100, ErrorMessage = "Müşteri adı en fazla 100 karakter olabilir!")]
        public string CustomerName { get; set; }=string.Empty;

        [Required(ErrorMessage = "Rezervasyon tarihi boş olamaz!")]
        public DateTime ReservationDate { get; set; }

        [Required(ErrorMessage = "Rezervasyon durumu gerekli!")]
        public string Status { get; set; } = "active";
    }
}

