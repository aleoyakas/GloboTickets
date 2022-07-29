using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GlobalTickets.Services.EventCatalog.Entities
{
    public class CategoryEntity
    {
        [Key]
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public List<EventEntity> Events { get; set; }
    }
}
