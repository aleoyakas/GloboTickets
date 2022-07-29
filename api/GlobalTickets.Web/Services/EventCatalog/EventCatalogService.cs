using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GloboTickets.Web.Extensions;
using GloboTickets.Web.Models.Api;

namespace GloboTickets.Web.Services.EventCatalog
{
    public class EventCatalogService : IEventService, ICategoryService
    {
        private readonly HttpClient client;
        private readonly string _baseAddress = "https://localhost:5001";

        public EventCatalogService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            var response = await client.GetAsync($"{_baseAddress}/api/events");
            return await response.ReadContentAs<List<Event>>();
        }

        public async Task<IEnumerable<Event>> GetByCategoryId(Guid categoryid)
        {
            var response = await client.GetAsync($"{_baseAddress}/api/events/?categoryId={categoryid}");
            return await response.ReadContentAs<List<Event>>();
        }

        public async Task<Event> GetEvent(Guid id)
        {
            var response = await client.GetAsync($"{_baseAddress}/api/events/{id}");
            return await response.ReadContentAs<Event>();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var response = await client.GetAsync($"{_baseAddress}/api/categories");
            return await response.ReadContentAs<List<Category>>();
        }
    }
}
