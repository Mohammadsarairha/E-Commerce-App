using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Bazar_App.Data;
using Bazar_App.Models.DTO;
using Bazar_App.Models.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazar_App.Models.Services
{
    public class ProductServices : IProduct
    {
        private readonly BazaarDBContext _context;
        private readonly IConfiguration configuration;
        public ProductServices(BazaarDBContext context , IConfiguration config)
        {
            _context = context;
            configuration = config;
        }

        public async Task<ProductDto> Create(Product product)
        {
            _context.Entry(product).State = EntityState.Added;
            await _context.SaveChangesAsync();

            ProductDto productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ImgUrl = product.ImgUrl,
                InStock = product.InStock,
                CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == product.CategoryId).Name
            };

            return productDto;
        }

        public async Task<ProductDto> GetProduct(int Id)
        {
            return await _context.Product.Select(X => new ProductDto
            {
                Id = X.Id,
                Name = X.Name,
                Price = X.Price,
                Description = X.Description,
                ImgUrl = X.ImgUrl,
                InStock = X.InStock,
                CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == X.CategoryId).Name
            }).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            return await _context.Product.Select(X => new ProductDto
            {
                Id = X.Id,
                Name = X.Name,
                Price = X.Price,
                Description = X.Description,
                ImgUrl = X.ImgUrl,
                InStock=X.InStock,
                CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == X.CategoryId).Name
            }).ToListAsync();
        }

        public async Task<ProductDto> Update(int Id, Product product)
        {
            ProductDto productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImgUrl = product.ImgUrl,
                InStock = product.InStock,
                CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == product.CategoryId).Name
            };
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return productDto;
        }

        public async Task Delete(int id)
        {
            Product product = await _context.Product.FindAsync(id);
            _context.Entry(product).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public int GetProductCategory(string category)
        {
            int catId = _context.Categories.FirstOrDefault(cat => cat.Name == category).Id;

            return catId;
        }

        public async Task<List<Category>> GetCategories()
        {
            List<Category> categories = await _context.Categories.ToListAsync();

            return categories;
        }

        public async Task<string> Uplode(IFormFile file)
        {
            BlobContainerClient container = new BlobContainerClient(configuration.GetConnectionString("AzureContainers"), "img");
            await container.CreateIfNotExistsAsync();
            BlobClient blob = container.GetBlobClient(file.FileName);
            using var stream = file.OpenReadStream();

            BlobUploadOptions options = new BlobUploadOptions()
            {
                HttpHeaders = new BlobHttpHeaders() { ContentType = file.ContentType }
            }; if (!blob.Exists())
            {
                await blob.UploadAsync(stream, options);
            }
            stream.Close();

            string imgUrl = blob.Uri.ToString();

            return imgUrl;
        }
    }
}
