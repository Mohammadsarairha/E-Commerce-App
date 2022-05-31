using Bazar_App.Models;
using Bazar_App.Models.DTO;
using Bazar_App.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bazar_App.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory _category;

        public CategoryController(ICategory category)
        {
            _category = category;
        }


        public async Task<ActionResult<CategoryDto>> Index()
        {
            List<CategoryDto> categories = await _category.GetCategories();

            return View(categories);
        }

        public async Task<ActionResult<CategoryDto>> Details(int id)
        {
            CategoryDto category = await _category.GetCategory(id);

            return View(category);
        }
    }
}
