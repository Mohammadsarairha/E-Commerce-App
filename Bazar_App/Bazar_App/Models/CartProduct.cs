using System.ComponentModel.DataAnnotations.Schema;

namespace Bazar_App.Models
{
    public class CartProduct
    {
        public Cart Cart { get; set; }
        [ForeignKey("Cart")]
        public int CartId { get; set; }

        public Product Products { get; set; }
        [ForeignKey("Products")]
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
