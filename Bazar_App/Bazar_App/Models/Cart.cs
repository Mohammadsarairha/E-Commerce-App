using Bazar_App.Auth.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bazar_App.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public double TotalCost { get; set; }
        public int TotalQuantity { get; set; }
        public int State { get; set; }
        //ForeignKey
        public ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        //Navigation properties
        public List<CartProduct> CartProducts { get; set; }
    }
}
