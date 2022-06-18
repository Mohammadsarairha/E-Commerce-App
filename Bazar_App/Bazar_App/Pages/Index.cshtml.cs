using Bazar_App.Models.DTO;
using Bazar_App.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bazar_App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICategory _category;
        private readonly ICart _cart;
        public IndexModel(ICategory category,ICart cart)
        {
            _category = category;
            _cart = cart;
        }

        [BindProperty]
        public List<CategoryDto> category { get; set; }

        public async Task OnGet()
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = new System.DateTimeOffset(DateTime.Now.AddDays(7));
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            CartDto cartData = await _cart.GetUserCart(userId);
            if (cartData != null)
            {
                HttpContext.Response.Cookies.Append("count", cartData.TotalQuantity.ToString(), cookieOptions);
            }
            category = await _category.GetCategories();
        }

        public IActionResult OnPost(int id)
        {
            return Redirect($"/Products?id={id}");
        }
    }
}
