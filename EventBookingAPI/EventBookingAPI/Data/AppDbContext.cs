using Microsoft.EntityFrameworkCore;
using EventBookingAPI.Models;


namespace EventBookingAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Events> Events { get; set; }
    }
}
