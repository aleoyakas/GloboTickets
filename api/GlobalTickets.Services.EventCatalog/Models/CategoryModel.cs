using System;

namespace GlobalTickets.Services.EventCatalog.Models
{
    // This was described as a DTO in the course - is that correct?
    public class CategoryModel
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
    }
}
