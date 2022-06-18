namespace Bazar_App.Models.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public int InStock { get; set; }
        public string ImgUrl { get; set; }
        public int Quantity { get; set; }
    }
}
