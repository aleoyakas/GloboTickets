using System;
using System.Threading.Tasks;
using GlobalTickets.Services.ShoppingBasket.Entities;

namespace GlobalTickets.Services.ShoppingBasket.Repositories
{
    public interface IEventRepository
    {
        void AddEvent(EventEntity theEvent);
        Task<bool> EventExists(Guid eventId);
        Task<bool> SaveChanges();
    }
}