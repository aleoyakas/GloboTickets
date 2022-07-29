using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GloboTickets.Web.Models.Api;
using GloboTickets.Web.Services.EventCatalog;
using Microsoft.AspNetCore.Mvc;

namespace GloboTickets.Web.Controllers
{
    [Route("api/categories")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _categoryService.GetCategories();
            return Ok(categories);
        }
    }
}
