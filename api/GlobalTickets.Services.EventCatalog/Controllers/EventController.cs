using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GlobalTickets.Services.EventCatalog.Models;
using GlobalTickets.Services.EventCatalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GlobalTickets.Services.EventCatalog.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventController(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventModel>>> GetEvents(
            [FromQuery] Guid categoryId)
        {
            var result = await _eventRepository.GetEvents(categoryId);
            return Ok(_mapper.Map<List<EventModel>>(result));
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<EventModel>> GetEventsById(Guid eventId)
        {
            var result = await _eventRepository.GetEventById(eventId);
            return Ok(_mapper.Map<EventModel>(result));
        }
    }
}