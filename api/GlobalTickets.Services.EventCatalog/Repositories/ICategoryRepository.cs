using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using GlobalTickets.Services.EventCatalog.Entities;

namespace GlobalTickets.Services.EventCatalog.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryEntity>> GetAllCategories();
        Task<CategoryEntity> GetCategoryById(string categoryId);
    }
}