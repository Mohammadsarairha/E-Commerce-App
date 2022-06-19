using Bazar_App.Models;
using Bazar_App.Models.DTO;
using Bazar_App.Models.Interface;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Administrator,Editor")]
        public async Task<ActionResult<CategoryDto>> Index()
        {
            List<CategoryDto> categories = await _category.GetCategories();

            return View(categories);
        }
        [Authorize(Roles = "Administrator,Editor")]
        public async Task<ActionResult<CategoryDto>> Details(int id)
        {
            CategoryDto category = await _category.GetCategory(id);

            return View(category);
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<ActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _category.Create(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }
        [Authorize(Roles = "Editor")]
        public async Task<ActionResult<Category>> Edit(int id)
        {
            CategoryDto categoryDto = await _category.GetCategory(id);

            Category category = new Category
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name
            };

            return View(category);
        }
        [Authorize(Roles = "Editor")]
        [HttpPost]
        public async Task<ActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                await _category.Update(category.Id, category);

                return RedirectToAction("Index");
            }

            return View(category);
        }
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(int id)
        {
            await _category.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
