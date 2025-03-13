using System.ComponentModel.DataAnnotations;

public class Events
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Etkinlik adı boş olamaz!")]
    public string Name { get; set; }=string.Empty;

    [Required(ErrorMessage = "Etkinlik tarihi belirtilmelidir.")]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "Etkinlik mekanı belirtilmelidir.")]
    public string Venue { get; set; }=string.Empty;
}
