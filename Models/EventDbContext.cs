using Microsoft.EntityFrameworkCore;

namespace Modas.Models
{
  public class EventDbContext : DbContext
  {
    public EventDbContext(DbContextOptions<EventDbContext> options) : base(options) { }
    public DbSet<Event> Events { get; set; }
    public DbSet<Location> Locations { get; set; }
  }
}
