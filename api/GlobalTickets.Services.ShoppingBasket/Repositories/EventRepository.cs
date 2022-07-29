using System;
using System.Threading.Tasks;
using GlobalTickets.Services.ShoppingBasket.DbContexts;
using GlobalTickets.Services.ShoppingBasket.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlobalTickets.Services.ShoppingBasket.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ShoppingBasketDbContext _shoppingBasketDbContext;

        public EventRepository(ShoppingBasketDbContext shoppingBasketDbContext)
        {
            _shoppingBasketDbContext = shoppingBasketDbContext;
        }

        public async Task<bool> EventExists(Guid eventId)
        {
            return await _shoppingBasketDbContext.Events.AnyAsync(e => e.EventId == eventId);
        }

        public void AddEvent(EventEntity theEvent)
        {
            _shoppingBasketDbContext.Events.Add(theEvent);

        }

        public async Task<bool> SaveChanges()
        {
            return (await _shoppingBasketDbContext.SaveChangesAsync() > 0);
        }
    }
}
