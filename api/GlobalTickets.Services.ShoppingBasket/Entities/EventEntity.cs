using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalTickets.Services.ShoppingBasket.Entities
{
    public class EventEntity
    {
        [Key]
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
