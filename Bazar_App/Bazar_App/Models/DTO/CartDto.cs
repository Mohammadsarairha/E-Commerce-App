using System.Collections.Generic;

namespace Bazar_App.Models.DTO
{
    public class CartDto
    {
        public int Id { get; set; }
        public double TotalCost { get; set; }
        public int TotalQuantity { get; set; }
        public string UserId { get; set; }
        // To Many to many Relation between Cart And Product
        public List<ProductDto> Products { get; set; }
    }
}
