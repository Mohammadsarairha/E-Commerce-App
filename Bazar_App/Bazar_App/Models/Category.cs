using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bazar_App.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Imgurl { get; set; }
        //Navigation properties
        public List<Product> Products { get; set; }
    }
}
