using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GloboTickets.Web.Models.Api;

namespace GloboTickets.Web.Services.ShoppingBasket
{
    public interface IBasketService
    {
        Task<Basket> GetUserBasket(Guid userId);
        Task<Basket> GetBasket(Guid basketId);
        Task<Basket> AddBasket(BasketForCreation basketForCreation);
    }
}
