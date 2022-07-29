using GlobalTickets.Services.ShoppingBasket.DbContexts;
using GlobalTickets.Services.ShoppingBasket.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTickets.Services.ShoppingBasket.Repositories
{
    public class BasketLinesRepository : IBasketLinesRepository
    {
        private readonly ShoppingBasketDbContext _shoppingBasketDbContext;

        public BasketLinesRepository(ShoppingBasketDbContext shoppingBasketDbContext)
        {
            _shoppingBasketDbContext = shoppingBasketDbContext;
        }

        public async Task<IEnumerable<BasketLineEntity>> GetBasketLines(Guid basketId)
        {
            return await _shoppingBasketDbContext.BasketLines.Include(bl => bl.Event)
                .Where(b => b.BasketId == basketId).ToListAsync();
        }

        public async Task<BasketLineEntity> GetBasketLineById(Guid basketLineId)
        {
            return await _shoppingBasketDbContext.BasketLines.Include(bl => bl.Event)
                .Where(b => b.BasketLineId == basketLineId).FirstOrDefaultAsync();
        }

        public async Task<BasketLineEntity> AddOrUpdateBasketLine(Guid basketId, BasketLineEntity basketLine)
        {
            var existingLine = await _shoppingBasketDbContext.BasketLines.Include(bl => bl.Event)
                .Where(b => b.BasketId == basketId && b.EventId == basketLine.EventId).FirstOrDefaultAsync();
            if (existingLine == null)
            {
                basketLine.BasketId = basketId;
                _shoppingBasketDbContext.BasketLines.Add(basketLine);
                return basketLine;
            }
            existingLine.TicketAmount += basketLine.TicketAmount;
            return existingLine;
        }

        public void UpdateBasketLine(BasketLineEntity basketLine)
        {
            // empty on purpose
        }
        
        public void RemoveBasketLine(BasketLineEntity basketLine)
        {
            _shoppingBasketDbContext.BasketLines.Remove(basketLine);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _shoppingBasketDbContext.SaveChangesAsync() > 0);
        }
    }
}
