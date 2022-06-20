using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Bazar_App.Models.DTO
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Imgurl { get; set; }
        public IFormFile File { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
