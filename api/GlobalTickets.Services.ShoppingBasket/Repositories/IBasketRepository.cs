using GlobalTickets.Services.ShoppingBasket.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobalTickets.Services.ShoppingBasket.Repositories
{
    public interface IBasketRepository
    {
        Task<bool> BasketExists(Guid basketId);

        Task<BasketEntity> GetUserBasket(Guid userId);

        Task<BasketEntity> GetBasketById(Guid basketId);

        void AddBasket(BasketEntity basket);

        Task<bool> SaveChanges();
    }
}