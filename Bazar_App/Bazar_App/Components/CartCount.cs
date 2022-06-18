using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bazar_App.Components
{
    public class CartCount : ViewComponent
    {
        public class ViewComponentModel
        {
            public string Count { get; set; }
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewComponentModel cartData = new ViewComponentModel { Count = HttpContext.Request.Cookies["count"] };
            return await Task.FromResult(View(cartData));
        }
    }
}
