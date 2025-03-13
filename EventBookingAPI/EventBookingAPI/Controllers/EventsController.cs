using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventBookingAPI.Data;
using EventBookingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

[Route("api/[controller]")]
[ApiController]
public class EventsController : ControllerBase
{
    private readonly AppDbContext _context;

    public EventsController(AppDbContext context)
    {
        _context = context;
    }

    // Tüm etkinlikleri getir
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Events>>> GetEvents()
    {
        return await _context.Events.ToListAsync();
    }

    // Belirli bir etkinliği getir
    [HttpGet("{id}")]
    public async Task<ActionResult<Events>> GetEvent(int id)
    {
        var evnt = await _context.Events.FindAsync(id);
        if (evnt == null)
            return NotFound();

        return evnt;
    }

    // Yeni etkinlik oluştur
    [HttpPost]
    public async Task<ActionResult<Events>> CreateEvent(Events evnt)
    {
        _context.Events.Add(evnt);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetEvent), new { id = evnt.Id }, evnt);
    }

    // Etkinliği güncelle
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEvent(int id, Events evnt)
    {
        if (id != evnt.Id)
            return BadRequest();

        _context.Entry(evnt).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // Etkinliği sil
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        var evnt = await _context.Events.FindAsync(id);
        if (evnt == null)
            return NotFound();

        _context.Events.Remove(evnt);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
