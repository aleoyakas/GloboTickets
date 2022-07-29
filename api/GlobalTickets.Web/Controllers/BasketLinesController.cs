using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GloboTickets.Web.Models.Api;
using GloboTickets.Web.Services.ShoppingBasket;
using Microsoft.AspNetCore.Mvc;

namespace GloboTickets.Web.Controllers
{
    [Route("api/baskets/{basketId}/basketlines")]
    [ApiController]
    public class BasketLinesController : ControllerBase
    {
        private readonly IBasketLineService _basketLineService;

        public BasketLinesController(IBasketLineService basketLineService)
        {
            _basketLineService = basketLineService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasketLine>>> GetBasketLines(
            Guid basketId
        )
        {
            var basketLines = await _basketLineService.GetBasketLines(basketId);
            return Ok(basketLines);             
        }

        [HttpGet("{basketLineId}")]
        public async Task<ActionResult<BasketLine>> GetBasketLineById(
            Guid basketId, 
            Guid basketLineId
        )
        {
            var basketLine = await _basketLineService.GetBasketLine(basketId, basketLineId);
            return Ok(basketLine);
        }

        [HttpPost]
        public async Task<ActionResult<BasketLine>> CreateBasketLine(
            Guid basketId, 
            [FromBody] BasketLineForCreation basketLineForCreation
        )
        {
            var basketLine = await _basketLineService.CreateBasketLine(basketId, basketLineForCreation);
            return Created("dummy", basketLine);
        } 

        [HttpPut("{basketLineId}")]
        public async Task<ActionResult<BasketLine>> Put(
            Guid basketId, 
            Guid basketLineId, 
            [FromBody] BasketLineForUpdate basketLineForUpdate
        )
        {
            var basketLine = await _basketLineService.UpdateBasketLine(basketId, basketLineId, basketLineForUpdate);
            return Created("dummy", basketLine);
        } 

        [HttpDelete("{basketLineId}")]
        public async Task<IActionResult> Delete(
            Guid basketId, 
            Guid basketLineId
        )
        {
            await _basketLineService.DeleteBasketLine(basketId, basketLineId);
            return NoContent();
        }
    }
}
