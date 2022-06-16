using Bazar_App.Models;
using Bazar_App.Models.DTO;
using Bazar_App.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bazar_App.Pages.Products
{
    
    public class IndexModel : PageModel
    {
        private readonly IProduct _prouduct;
        private readonly ICategory _category;

        public IndexModel(IProduct prouduct, ICategory category)
        {
            _prouduct = prouduct;
            _category = category;
        }

        [BindProperty]
        public List<ProductDto> Product { get; set; }

        public async Task OnGet(int id)
        {
            CategoryDto category = await _category.GetCategory(id);
            Product = category.Products;
        }

        public IActionResult OnPost(int id)
        {
            return Redirect($"/Carts?id={id}");
        }
    }
}
