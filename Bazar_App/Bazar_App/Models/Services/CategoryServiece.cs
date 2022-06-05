﻿using Bazar_App.Data;
using Bazar_App.Models.DTO;
using Bazar_App.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazar_App.Models.Services
{
    public class CategoryServiece : ICategory
    {
        private readonly BazaarDBContext _context;

        public CategoryServiece(BazaarDBContext context)
        {
            _context = context;
        }

        public async Task<CategoryDto> Create(Category category)
        {
            _context.Entry(category).State = EntityState.Added;

            await _context.SaveChangesAsync();

            CategoryDto categorydto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };

            return categorydto;
        }

        public async Task<List<CategoryDto>> GetCategories()
        {
            return await _context.Categories.Select(category => new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Products = category.Products.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == p.CategoryId).Name
                }).ToList()
            }).ToListAsync();
        }

        public async Task<CategoryDto> GetCategory(int id)
        {
            return await _context.Categories.Select(category => new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Products = category.Products.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == p.CategoryId).Name
                }).ToList()
            }).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<CategoryDto> Update(int id, Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            CategoryDto categoryDto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };

            return categoryDto;
        }

        public async Task Delete(int id)
        {
            Category category = await _context.Categories.FindAsync(id);
            _context.Entry(category).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
