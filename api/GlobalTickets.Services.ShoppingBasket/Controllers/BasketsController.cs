using System;
using System.Threading.Tasks;
using AutoMapper;
using GlobalTickets.Services.ShoppingBasket.Models;
using GlobalTickets.Services.ShoppingBasket.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace GlobalTickets.Services.ShoppingBasket.Controllers
{
    [Route("api/baskets")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketsController(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Basket>> GetUserBasket([FromQuery] Guid userId)
        {
            var basket = await _basketRepository.GetUserBasket(userId);
            if (basket is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Basket>(basket));
        }

        [HttpGet("{basketId}")]
        public async Task<ActionResult<Basket>> GetBasketById(Guid basketId)
        {
            var basket = await _basketRepository.GetBasketById(basketId);
            if (basket == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<Basket>(basket);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Basket>> CreateBasket(BasketForCreation basketForCreation)
        {
            var basketEntity = _mapper.Map<Entities.BasketEntity>(basketForCreation);

            _basketRepository.AddBasket(basketEntity);
            await _basketRepository.SaveChanges();

            var basketCreated = _mapper.Map<Basket>(basketEntity);

            return Ok(basketCreated);
        }
    }
}
