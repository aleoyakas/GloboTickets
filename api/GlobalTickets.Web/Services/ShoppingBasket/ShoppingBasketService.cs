using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GloboTickets.Web.Extensions;
using GloboTickets.Web.Models.Api;

namespace GloboTickets.Web.Services.ShoppingBasket
{
    public class ShoppingBasketService: IBasketService, IBasketLineService
    {
        private readonly HttpClient _client;
        private readonly string _baseAddress = "https://localhost:5003";

        public ShoppingBasketService(HttpClient client)
        {
            _client = client;
        }

        public async Task<BasketLine> CreateBasketLine(Guid basketId, BasketLineForCreation basketLine)
        {
            var basket = await GetBasket(basketId);
            if (basket == null)
            {
                throw new Exception("BasketNotFound");
            }

            var response = await _client.PostAsJson($"{_baseAddress}/api/baskets/{basketId}/basketlines", basketLine);
            return await response.ReadContentAs<BasketLine>();
        }

        public async Task<Basket> GetBasket(Guid basketId)
        {
            if (basketId == Guid.Empty)
            {
                return null;
            }

            var response = await _client.GetAsync($"{_baseAddress}/api/baskets/{basketId}");
            return await response.ReadContentAs<Basket>();
        }

        public async Task<IEnumerable<BasketLine>> GetBasketLines(Guid basketId)
        {
            if (basketId == Guid.Empty)
                return new BasketLine[0];
            var response = await _client.GetAsync($"{_baseAddress}/api/baskets/{basketId}/basketLines");
            return await response.ReadContentAs<BasketLine[]>();
        }

        public async Task<BasketLine> UpdateBasketLine(Guid basketId, Guid basketLineId, BasketLineForUpdate basketLineForUpdate)
        {
            var response = await _client.PutAsJson($"{_baseAddress}/api/baskets/{basketId}/basketLines/{basketLineId}", basketLineForUpdate);
            return await response.ReadContentAs<BasketLine>();
        }

        public async Task DeleteBasketLine(Guid basketId, Guid lineId)
        {
            await _client.DeleteAsync($"{_baseAddress}/api/baskets/{basketId}/basketLines/{lineId}");
        }

        public async Task<Basket> AddBasket(BasketForCreation basketForCreation)
        {
            var response = await _client.PostAsJson($"{_baseAddress}/api/baskets", basketForCreation);
            return await response.ReadContentAs<Basket>();
        }

        public async Task<Basket> GetUserBasket(Guid userId)
        {
            var response = await _client.GetAsync($"{_baseAddress}/api/baskets?userId={userId}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.ReadContentAs<Basket>();
        }

        public async Task<BasketLine> GetBasketLine(Guid basketId, Guid basketLineId)
        {
            var response = await _client.GetAsync($"{_baseAddress}/api/baskets/${basketId}/basketLines/{basketLineId}");
            return await response.ReadContentAs<BasketLine>();
        }
    }
}
