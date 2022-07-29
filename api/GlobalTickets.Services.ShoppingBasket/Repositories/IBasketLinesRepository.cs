using GlobalTickets.Services.ShoppingBasket.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobalTickets.Services.ShoppingBasket.Repositories
{
    public interface IBasketLinesRepository
    {
        Task<IEnumerable<BasketLineEntity>> GetBasketLines(Guid basketId);

        Task<BasketLineEntity> GetBasketLineById(Guid basketLineId);

        Task<BasketLineEntity> AddOrUpdateBasketLine(Guid basketId, BasketLineEntity basketLine);

        void UpdateBasketLine(BasketLineEntity basketLine);

        void RemoveBasketLine(BasketLineEntity basketLine);

        Task<bool> SaveChanges();
    }
}