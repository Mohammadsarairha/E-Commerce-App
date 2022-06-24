using Bazar_App.Models;
using Bazar_App.Models.DTO;
using Bazar_App.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bazar_App.Pages.Checkouts
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ICheckout _checkout;
        private readonly ICart _cart;
        public IndexModel(ICheckout checkout , ICart cart)
        {
            _checkout = checkout;
            _cart = cart;
        }

        [BindProperty]
        public Checkout checkout { get; set; }
        public CartDto userCart { get; set; }

        public async Task OnGet()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_cart.GetCartByUserId(userId, 0))
            {
                userCart = await _cart.GetUserCart(userId, 0);
                if (userCart != null)
                {
                    bool checkUserCheckout = _checkout.GetUserCheckout(userId, userCart.Id);
                    if (checkUserCheckout)
                    {
                        checkout = await _checkout.GetCheckoutForUser(userId, userCart.Id);
                    }
                }
            }
        }

        public async Task<ActionResult> OnPost(Checkout checkout)
        {
                if (ModelState.IsValid)
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    userCart = await _cart.GetUserCart(userId, 0);  
                    checkout.UserId = userCart.UserId;
                    checkout.CartId = userCart.Id;
                    await _checkout.Create(checkout);
                    return Redirect("/Invoices");
                }
                else
                {
                    return Page();
                }
            
        }
    }
}
