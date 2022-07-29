using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GlobalTickets.Services.EventCatalog.Models;
using GlobalTickets.Services.EventCatalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GlobalTickets.Services.EventCatalog.Controllers
{
    [Route("api/categories")]
    public class CategoryController: ControllerBase
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> Get()
        {
            var result = await _categoryRepository.GetAllCategories();
            return Ok(_mapper.Map<List<CategoryModel>>(result));
        }
    }
}
