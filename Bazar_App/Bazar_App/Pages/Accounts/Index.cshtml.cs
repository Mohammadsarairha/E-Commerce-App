using Bazar_App.Auth.Interfaces;
using Bazar_App.Auth.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Bazar_App.Pages.Accounts
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        [BindProperty]
        public LoginDto loginData { get; set; }

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (loginData.Username != null && loginData.Password != null)
            {
                var user = await _userService.Authenticate(loginData.Username, loginData.Password);
                if (user == null)
                {
                    ModelState.AddModelError("loginData.Password", "Password and username not match");
                }
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return Redirect("/");
        }
    }
}
