﻿using System;
using System.ComponentModel.DataAnnotations;

namespace GloboTickets.Web.Models.Api
{
    public class BasketLineForCreation
    {
        [Required]
        public Guid EventId { get; set; }
        [Required]
        public int TicketAmount { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
