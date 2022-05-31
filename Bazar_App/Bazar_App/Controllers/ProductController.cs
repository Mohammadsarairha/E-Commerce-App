using Bazar_App.Models.DTO;
using Bazar_App.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bazar_App.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _prouduct;

        public ProductController(IProduct prouduct)
        {
            _prouduct = prouduct;
        }

        public async Task<ActionResult<ProductDto>> Index()
        {
            List<ProductDto> products = await _prouduct.GetProducts();

            return View(products);
        }

        public async Task<ActionResult<ProductDto>> Details(int id)
        {
            ProductDto product = await _prouduct.GetProduct(id);

            return View(product);
        }
    }
}
