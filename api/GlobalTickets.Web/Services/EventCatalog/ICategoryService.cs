using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GloboTickets.Web.Models.Api;

namespace GloboTickets.Web.Services.EventCatalog
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategories();
    }
}
