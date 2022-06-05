using Microsoft.AspNetCore.Mvc;

namespace Bazar_App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
