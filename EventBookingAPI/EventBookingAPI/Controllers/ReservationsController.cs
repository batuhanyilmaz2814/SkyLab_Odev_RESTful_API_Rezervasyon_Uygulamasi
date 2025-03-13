using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventBookingAPI.Data;
using EventBookingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ReservationsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ReservationsController(AppDbContext context)
    {
        _context = context;
    }

    // Tüm rezervasyonları getir
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
    {
        return await _context.Reservations.ToListAsync();
    }

    // Belirli bir rezervasyonu getir
    [HttpGet("{id}")]
    public async Task<ActionResult<Reservation>> GetReservation(int id)
    {
        var reservation = await _context.Reservations.FindAsync(id);
        if (reservation == null)
            return NotFound();

        return reservation;
    }

    // Yeni rezervasyon oluştur
    /*[HttpPost]
    public async Task<ActionResult<Reservation>> CreateReservation(Reservation reservation)
    {
        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetReservation), new { id = reservation.Id }, reservation);
    }
    */
    // Rezervasyonu güncelle
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReservation(int id, Reservation reservation)
    {
        if (id != reservation.Id)
            return BadRequest();

        _context.Entry(reservation).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // Rezervasyonu sil
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReservation(int id)
    {
        var reservation = await _context.Reservations.FindAsync(id);
        if (reservation == null)
            return NotFound();

        _context.Reservations.Remove(reservation);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // Yeni Rzervasyon güncellenmiş kısım
    [HttpPost]
    public async Task<IActionResult> CreateReservation([FromBody] Reservation reservation)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        //  Önlem: Aynı bilet daha önce rezerve edilmiş mi?
        var existingReservation = await _context.Reservations
            .FirstOrDefaultAsync(r => r.TicketId == reservation.TicketId);

        if (existingReservation != null)
        {
            return Conflict(new { message = "Bu bilet zaten rezerve edilmiş!" });
        }

        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(CreateReservation), new { id = reservation.Id }, reservation);
    }

    [HttpGet("stats")]
    public async Task<IActionResult> GetReservationStats()
    {
        var totalReservations = await _context.Reservations.CountAsync();
        var pendingReservations = await _context.Reservations.CountAsync(r => r.Status == "Pending");
        var confirmedReservations = await _context.Reservations.CountAsync(r => r.Status == "Confirmed");

        return Ok(new
        {
            TotalReservations = totalReservations,
            PendingReservations = pendingReservations,
            ConfirmedReservations = confirmedReservations
        });
    }

}

