using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GloboTickets.Web.Models.Api;
using GloboTickets.Web.Services.EventCatalog;
using Microsoft.AspNetCore.Mvc;

namespace GloboTickets.Web.Controllers
{
    [Route("api/events")]
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents([FromQuery] Guid categoryId)
        {
            IEnumerable<Event> events;
            if (categoryId == Guid.Empty)
            {
                events = await _eventService.GetAll();
            }
            else
            {
                events = await _eventService.GetByCategoryId(categoryId);
            }
            return Ok(events);
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<Event>> GetEvent(
            Guid eventId)
        {
            var eventResp = await _eventService.GetEvent(eventId);
            return Ok(eventResp);
        }
    }
}
