using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bazar_App.Models.DTO
{
    public class ProductCategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
        public string ImgUrl { get; set; }
        public int InStock { get; set; }
        public string CategoryName { get; set; }

        public List<Category> Categories { get; set; }
    }
}
