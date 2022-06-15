using Bazar_App.Models.DTO;
using Bazar_App.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bazar_App.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProduct _prouduct;

        public IndexModel(IProduct prouduct)
        {
            _prouduct = prouduct;
        }

        [BindProperty]
        public ProductDto Product { get; set; }

        public async void OnGet(int id)
        {
            Product = await _prouduct.GetProduct(id);
        }
    }
}
