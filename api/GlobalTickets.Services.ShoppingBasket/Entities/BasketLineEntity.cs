using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalTickets.Services.ShoppingBasket.Entities
{
    public class BasketLineEntity
    {
        [Key]
        public Guid BasketLineId { get; set; }
        [Required]
        public Guid BasketId { get; set; }
        [Required]
        public Guid EventId { get; set; }
        public EventEntity Event { get; set; }
        [Required]
        public int TicketAmount { get; set; }
        [Required]
        public int Price { get; set; }
        public BasketEntity Basket { get; set; }
    }
}
