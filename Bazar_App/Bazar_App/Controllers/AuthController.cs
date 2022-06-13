using Bazar_App.Auth.Interfaces;
using Bazar_App.Auth.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bazar_App.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult SignUp()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Auth");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();

            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> SignUp(RegisterDto register)
        {
            if (register.UserName != null && register.Email != null && register.Password != null)
            {
                await _userService.Register(register, this.ModelState);
            }

            if (ModelState.IsValid)
            {
                return Redirect("/");
            }

            return View();
        }
        [HttpPost]
        public async Task<ActionResult<UserDto>> Authenticate(LoginDto login)
        {
            var user = await _userService.Authenticate(login.UserName, login.Password);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            return Redirect("/");
        }
    }
}
