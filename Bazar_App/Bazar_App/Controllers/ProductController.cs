using Bazar_App.Models;
using Bazar_App.Models.DTO;
using Bazar_App.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
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

        public async Task<ActionResult> Create()
        {
            ProductCategoryDto categoryDto = new ProductCategoryDto
            {
                Categories= await _prouduct.GetCategories()
            };

            return View(categoryDto);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductCategoryDto newProduct)
        {
            newProduct.Categories = await _prouduct.GetCategories();

            Product product = new Product
            {
                Id = newProduct.Id,
                Name = newProduct.Name,
                Price = newProduct.Price,
                Description = newProduct.Description,
                CategoryId = _prouduct.GetProductCategory(newProduct.CategoryName)
            };
            //newProduct.CategoryId = _prouduct.GetProductCategory(newProduct.Category.Name);

            if (newProduct.Price <= 0)
            {
                ModelState.AddModelError("Price", "The Price must be more than zero");
            }

            if (ModelState.IsValid)
            {
                await _prouduct.Create(product);

                return RedirectToAction("Index");
            }
            return View(newProduct);
        }

        public async Task<ActionResult<Product>> Edit(int id)
        {
            ProductDto productDto = await _prouduct.GetProduct(id);

            Product product = new Product
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Price = productDto.Price,
                Description = productDto.Description,
                CategoryId = _prouduct.GetProductCategory(productDto.CategoryName)
            };

            return View(product);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Product product)
        {
            product.CategoryId = _prouduct.GetProductCategory(product.Category.Name);

            if (product.Price <= 0)
            {
                ModelState.AddModelError("Price", "The Price must be more than zero");
            }

            if (ModelState.IsValid)
            {
                await _prouduct.Update(product.Id,product);

                return RedirectToAction("Index");
            }

            return View(product);
        }

        public async Task<ActionResult> Delete(int id)
        {
            await _prouduct.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
