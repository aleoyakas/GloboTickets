using GlobalTickets.Services.ShoppingBasket.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlobalTickets.Services.ShoppingBasket.DbContexts
{
    public class ShoppingBasketDbContext : DbContext
    {
        public ShoppingBasketDbContext(DbContextOptions<ShoppingBasketDbContext> options)
        : base(options)
        {
        }

        public DbSet<BasketEntity> Baskets { get; set; }
        public DbSet<BasketLineEntity> BasketLines { get; set; }
        public DbSet<EventEntity> Events { get; set; }
    }
}
