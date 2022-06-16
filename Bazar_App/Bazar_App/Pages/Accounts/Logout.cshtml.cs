using Bazar_App.Auth.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Bazar_App.Pages.Accounts
{
    public class LogoutModel : PageModel
    {
        private readonly IUserService _userService;

        public LogoutModel(IUserService userService)
        {
            _userService = userService;
        }


        public async Task<IActionResult> OnGet()
        {
            await _userService.Logout();

            return Redirect("/");
        }
    }
}
