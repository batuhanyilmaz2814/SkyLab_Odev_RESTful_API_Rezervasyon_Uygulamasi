using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventBookingAPI.Data;
using EventBookingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class TicketsController : ControllerBase
{
    private readonly AppDbContext _context;

    public TicketsController(AppDbContext context)
    {
        _context = context;
    }

    // Tüm biletleri getir
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
    {
        return await _context.Tickets.ToListAsync();
    }

    // Belirli bir bileti getir
    [HttpGet("{id}")]
    public async Task<ActionResult<Ticket>> GetTicket(int id)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket == null)
            return NotFound();

        return ticket;
    }

    // Yeni bilet oluştur
    [HttpPost]
    public async Task<ActionResult<Ticket>> CreateTicket(Ticket ticket)
    {
        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTicket), new { id = ticket.Id }, ticket);
    }

    // Bileti güncelle
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTicket(int id, Ticket ticket)
    {
        if (id != ticket.Id)
            return BadRequest();

        _context.Entry(ticket).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // Bileti sil
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTicket(int id)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket == null)
            return NotFound();

        _context.Tickets.Remove(ticket);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}

