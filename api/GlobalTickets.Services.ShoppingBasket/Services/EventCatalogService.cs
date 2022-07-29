using System;
using System.Net.Http;
using System.Threading.Tasks;
using GlobalTickets.Services.ShoppingBasket.Entities;
using GlobalTickets.Services.ShoppingBasket.Extensions;

namespace GlobalTickets.Services.ShoppingBasket.Services
{
    public class EventCatalogService : IEventCatalogService
    {
        private readonly HttpClient client;

        public EventCatalogService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<EventEntity> GetEvent(Guid id)
        {
            var response = await client.GetAsync($"https://localhost:5001/api/events/{id}");
            return await response.ReadContentAs<EventEntity>();
        }
    }
}
