using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GlobalTickets.Services.ShoppingBasket.Models;
using GlobalTickets.Services.ShoppingBasket.Repositories;
using GlobalTickets.Services.ShoppingBasket.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlobalTickets.Services.ShoppingBasket.Controllers
{
    [Route("api/baskets/{basketId}/basketlines")]
    [ApiController]
    public class BasketLinesController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IBasketLinesRepository _basketLinesRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IEventCatalogService _eventCatalogService;
        private readonly IMapper _mapper;

        public BasketLinesController(IBasketRepository basketRepository, 
            IBasketLinesRepository basketLinesRepository, IEventRepository eventRepository, 
            IEventCatalogService eventCatalogService, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _basketLinesRepository = basketLinesRepository;
            _eventRepository = eventRepository;
            _eventCatalogService = eventCatalogService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasketLine>>> GetBasketLines(
            Guid basketId
        )
        {
            if (!await _basketRepository.BasketExists(basketId))
            {
                return NotFound();
            }

            var basketLines = await _basketLinesRepository.GetBasketLines(basketId);
            return Ok(_mapper.Map<IEnumerable<BasketLine>>(basketLines));             
        }

        [HttpGet("{basketLineId}")]
        public async Task<ActionResult<BasketLine>> GetBasketLineById(
            Guid basketId, 
            Guid basketLineId
        )
        {
            if (!await _basketRepository.BasketExists(basketId))
            {
                return NotFound();
            }

            var basketLine = await _basketLinesRepository.GetBasketLineById(basketLineId);
            if (basketLine == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BasketLine>(basketLine));
        }

        [HttpPost]
        public async Task<ActionResult<BasketLine>> CreateBasketLine(
            Guid basketId, 
            [FromBody] BasketLineForCreation basketLineForCreation
        )
        {
            if (!await _basketRepository.BasketExists(basketId))
            {
                return NotFound();
            }

            if (!await _eventRepository.EventExists(basketLineForCreation.EventId))
            {
                var eventFromCatalog = await _eventCatalogService.GetEvent(basketLineForCreation.EventId);
                _eventRepository.AddEvent(eventFromCatalog);
                await _eventRepository.SaveChanges();
            }

            var basketLineEntity = _mapper.Map<Entities.BasketLineEntity>(basketLineForCreation);

            var processedBasketLine = await _basketLinesRepository.AddOrUpdateBasketLine(basketId, basketLineEntity);
            await _basketLinesRepository.SaveChanges();

            return Created("dummy", _mapper.Map<BasketLine>(processedBasketLine));
        } 

        [HttpPut("{basketLineId}")]
        public async Task<ActionResult<BasketLine>> Put(Guid basketId, 
            Guid basketLineId, 
            [FromBody] BasketLineForUpdate basketLineForUpdate)
        {
            if (!await _basketRepository.BasketExists(basketId))
            {
                return NotFound();
            }

            var basketLineEntity = await _basketLinesRepository.GetBasketLineById(basketLineId);

            if (basketLineEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(basketLineForUpdate, basketLineEntity);

            _basketLinesRepository.UpdateBasketLine(basketLineEntity);
            await _basketLinesRepository.SaveChanges();

            return Ok(_mapper.Map<BasketLine>(basketLineEntity));
        } 

        [HttpDelete("{basketLineId}")]
        public async Task<IActionResult> Delete(Guid basketId, 
            Guid basketLineId)
        {
            if (!await _basketRepository.BasketExists(basketId))
            {
                return NotFound();
            }

            var basketLineEntity = await _basketLinesRepository.GetBasketLineById(basketLineId);

            if (basketLineEntity == null)
            {
                return NotFound();
            }

            _basketLinesRepository.RemoveBasketLine(basketLineEntity);
            await _basketLinesRepository.SaveChanges();

            return NoContent();
        }
    }
}
