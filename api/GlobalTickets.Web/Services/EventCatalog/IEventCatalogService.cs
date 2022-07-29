using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GloboTickets.Web.Models.Api;

namespace GloboTickets.Web.Services.EventCatalog
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAll();
        Task<IEnumerable<Event>> GetByCategoryId(Guid categoryid);
        Task<Event> GetEvent(Guid id);
    }
}
