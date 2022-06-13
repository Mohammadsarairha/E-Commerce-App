using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Bazar_App.Models;
using Bazar_App.Models.DTO;
using Bazar_App.Models.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        [Authorize]
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
            if (newProduct.File != null)
            {
                newProduct.ImgUrl = await _prouduct.Uplode(newProduct.File);
            }
            
            Product product = new Product
            {
                Id = newProduct.Id,
                Name = newProduct.Name,
                Price = newProduct.Price,
                Description = newProduct.Description,
                ImgUrl = newProduct.ImgUrl,
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
        [Authorize]
        public async Task<ActionResult> Edit(int id)
        {
            ProductDto productDto = await _prouduct.GetProduct(id);

            ProductCategoryDto product = new ProductCategoryDto
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Price = productDto.Price,
                Description = productDto.Description,
                ImgUrl = productDto.ImgUrl,
                Categories = await _prouduct.GetCategories()
            };

            return View(product);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ProductCategoryDto product)
        {
            product.ImgUrl = await _prouduct.Uplode(product.File);

            Product productNew = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ImgUrl = product.ImgUrl,
                CategoryId = _prouduct.GetProductCategory(product.CategoryName)
            };
            if (product.Price <= 0)
            {
                ModelState.AddModelError("Price", "The Price must be more than zero");
            }

            if (ModelState.IsValid)
            {
                await _prouduct.Update(product.Id, productNew);

                return RedirectToAction("Index");
            }

            return View(product);
        }
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            ProductDto productDto = await _prouduct.GetProduct(id);

            await _prouduct.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
