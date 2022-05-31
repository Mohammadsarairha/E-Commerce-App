using System.Collections.Generic;

namespace Bazar_App.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //Navigation properties
        public List<Product> Products { get; set; }
    }
}
