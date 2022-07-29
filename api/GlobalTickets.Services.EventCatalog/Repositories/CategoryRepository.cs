using GlobalTickets.Services.EventCatalog.DbContexts;
using GlobalTickets.Services.EventCatalog.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTickets.Services.EventCatalog.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly EventCatalogDbContext _eventCatalogDbContext;

        public CategoryRepository(EventCatalogDbContext eventCatalogDbContext)
        {
            _eventCatalogDbContext = eventCatalogDbContext;
        }


        public async Task<IEnumerable<CategoryEntity>> GetAllCategories()
        {
            return await _eventCatalogDbContext.Categories.ToListAsync();
        }

        public async Task<CategoryEntity> GetCategoryById(string categoryId)
        {
            return await _eventCatalogDbContext.Categories.Where(x => x.CategoryId.ToString() == categoryId).FirstOrDefaultAsync();
        }
    }
}
