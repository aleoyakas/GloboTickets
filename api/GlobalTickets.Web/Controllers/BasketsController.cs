using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GloboTickets.Web.Models.Api;
using GloboTickets.Web.Services.ShoppingBasket;
using Microsoft.AspNetCore.Mvc;


namespace GloboTickets.Web.Controllers
{
    [Route("api/baskets")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _shoppingBasketService;

        public BasketsController(IBasketService basketService)
        {
            _shoppingBasketService = basketService;
        }

        [HttpGet]
        public async Task<ActionResult<Basket>> GetUserBasket(Guid userId)
        {
            var basket = await _shoppingBasketService.GetUserBasket(userId);
            
            return Ok(basket);
        }

        [HttpGet("{basketId}")]
        public async Task<ActionResult<Basket>> GetBasket(Guid basketId)
        {
            var basket = await _shoppingBasketService.GetBasket(basketId);
            if (basket == null)
            {
                return NotFound();
            }

            return Ok(basket);
        }

        [HttpPost]
        public async Task<ActionResult<Basket>> CreateBasket(BasketForCreation basketForCreation)
        {
            var basketCreated = await _shoppingBasketService.AddBasket(basketForCreation);
            return Ok(basketCreated);
        }
    }
}
