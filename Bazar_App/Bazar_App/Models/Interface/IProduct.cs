using Bazar_App.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bazar_App.Models.Interface
{
    public interface IProduct
    {
        Task<ProductDto> Create(Product product);
        Task<List<ProductDto>> GetProducts();
        Task<ProductDto> GetProduct(int Id);
        Task<ProductDto> Update(int Id, Product product);
        Task Delete(int id);
        int GetProductCategory(string category);
        Task<List<Category>> GetCategories();
    }
}
