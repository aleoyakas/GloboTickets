using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GloboTickets.Web.Models.Api;

namespace GloboTickets.Web.Services.ShoppingBasket
{
    public interface IBasketLineService
    {
        Task<IEnumerable<BasketLine>> GetBasketLines(Guid basketId);
        Task<BasketLine> GetBasketLine(Guid basketId, Guid basketLineId);
        Task<BasketLine> CreateBasketLine(Guid basketId, BasketLineForCreation basketLine);
        Task<BasketLine> UpdateBasketLine(Guid basketId, Guid basketLineId, BasketLineForUpdate basketLineForUpdate);
        Task DeleteBasketLine(Guid basketId, Guid lineId);
    }
}
