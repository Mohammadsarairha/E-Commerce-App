using Bazar_App.Models;
using Bazar_App.Models.DTO;
using Bazar_App.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bazar_App.Pages.Products
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
        public List<ProductDto> Product { get; set; }

        public int CartId { get; set; }
        public async Task OnGet(int id)
        {
            CategoryDto category = await _category.GetCategory(id);
            Product = category.Products;
            CartId = id;
        }

        public async Task<IActionResult> OnPost(int id , int cartId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            CartDto cartData = null;
            if (_cart.GetCartByUserId(userId, 0))
            {
                cartData = await _cart.GetUserCart(userId, 0);
            }
            
            if (cartData == null)
            {
                Cart newCart = new Cart
                {
                    TotalCost = 0,
                    TotalQuantity = 0,
                    UserId = userId,
                    State = 0
                };
                cartData = await _cart.Create(newCart);
                await _cart.AddProductToCart(cartData.Id, id);
            }
            else
            {
                await _cart.AddProductToCart(cartData.Id, id);
            }
            if (cartData != null)
            {
                HttpContext.Response.Cookies.Append("count", cartData.TotalQuantity.ToString());
            }

            return Redirect($"/Products/{cartId}");
        }
    }
}


