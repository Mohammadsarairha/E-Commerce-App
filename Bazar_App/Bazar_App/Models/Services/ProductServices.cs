using Bazar_App.Data;
using Bazar_App.Models.DTO;
using Bazar_App.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazar_App.Models.Services
{
    public class ProductServices : IProduct
    {
        private readonly BazaarDBContext _context;

        public ProductServices(BazaarDBContext context)
        {
            _context = context;
        }

        public async Task<ProductDto> Create(Product product)
        {
            _context.Entry(product).State = EntityState.Added;
            await _context.SaveChangesAsync();

            ProductDto productDto = new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
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
    }
}
