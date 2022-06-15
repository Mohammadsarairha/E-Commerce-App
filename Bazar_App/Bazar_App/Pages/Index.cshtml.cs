using Bazar_App.Models.DTO;
using Bazar_App.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bazar_App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICategory _category;

        public IndexModel(ICategory category)
        {
            _category = category;
        }

        [BindProperty]
        public List<CategoryDto> category { get; set; }

        public async Task OnGet()
        {
            category = await _category.GetCategories();
        }

        public IActionResult OnPost(int id)
        {
            return Redirect($"/Products?id={id}");
        }
    }
}
