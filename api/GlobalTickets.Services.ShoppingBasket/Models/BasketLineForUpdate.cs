using System.ComponentModel.DataAnnotations;

namespace GlobalTickets.Services.ShoppingBasket.Models
{
    public class BasketLineForUpdate
    {
        [Required]
        public int TicketAmount { get; set; }
    }
}
