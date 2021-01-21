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
    [HttpGet("{id}")]
    // return specific event
    public Event Get(int id) => eventDbContext.Events
      .Include(e => e.Location)
      .FirstOrDefault(e => e.EventId == id);
    [HttpPost]
    // add event
    public Event Post([FromBody] Event evt) => eventDbContext.AddEvent(new Event
    {
      TimeStamp = evt.TimeStamp,
      Flagged = evt.Flagged,
      LocationId = evt.LocationId
    });
    [HttpPut]
    // update event
    public Event Put([FromBody] Event evt) => eventDbContext.UpdateEvent(evt);
  }
}
