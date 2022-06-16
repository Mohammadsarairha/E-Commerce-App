using Bazar_App.Models.DTO;
using Bazar_App.Models;
using Bazar_App.Models.Interface;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Bazar_App.Pages.Carts
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ICart _cart;

        public IndexModel(ICart cart)
        {
            _cart = cart;
        }

        public CartDto Cart { get; set; }

        public async Task OnGet(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            Cart = await _cart.GetUserCart(userId);

            if (Cart == null)
            {
                Cart newCart = new Cart
                {
                    TotalCost = 0,
                    TotalQuantity = 0,
                    UserId = userId
                };

                Cart = await _cart.Create(newCart);
                await _cart.AddProductToCart(Cart.Id , id);
            }
            else
            {
                await _cart.AddProductToCart(Cart.Id, id);
            }

            Cart = await _cart.GetCart(Cart.Id);
        }
    }
}
