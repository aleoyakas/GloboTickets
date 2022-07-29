using GlobalTickets.Services.EventCatalog.DbContexts;
using GlobalTickets.Services.EventCatalog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTickets.Services.EventCatalog.Repositories
{
    public class EventRepository: IEventRepository
    {
        private readonly EventCatalogDbContext _eventCatalogDbContext;

        public EventRepository(EventCatalogDbContext eventCatalogDbContext)
        {
            _eventCatalogDbContext = eventCatalogDbContext;
        }


        public async Task<IEnumerable<EventEntity>> GetEvents(Guid categoryId)
        {
            return await _eventCatalogDbContext.Events
                .Include(x => x.Category)
                .Where(x => (x.CategoryId == categoryId || categoryId == Guid.Empty)).ToListAsync();
        }

        public async Task<EventEntity> GetEventById(Guid eventId)
        {
            return await _eventCatalogDbContext.Events.Include(x => x.Category).Where(x => x.EventId == eventId).FirstOrDefaultAsync();
        }
    }
}
