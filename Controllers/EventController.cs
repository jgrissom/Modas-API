using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modas.Models;

namespace Modas.Controllers
{
  [Route("api/[controller]")]
  public class EventController : Controller
  {
    private EventDbContext eventDbContext;
    public EventController(EventDbContext db) => eventDbContext = db;

    [HttpGet]
    // returns all events (sorted)
    public IEnumerable<Event> Get() => eventDbContext.Events
      .Include(e => e.Location).OrderBy(e => e.TimeStamp);
  }
}
