using System.ComponentModel.DataAnnotations;
namespace Bazar_App.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double? Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        //Navigation properties
        public Category Category { get; set; }
    }
}