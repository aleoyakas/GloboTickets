using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace GlobalTickets.Services.ShoppingBasket.Entities
{
    public class BasketEntity
    {
        [Key]
        public Guid BasketId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public Collection<BasketLineEntity> BasketLines { get; set; }
    }
}
