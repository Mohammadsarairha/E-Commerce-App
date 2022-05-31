using Bazar_App.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Bazar_App.Models.Interface
{
    public interface ICategory
    {
        Task<CategoryDto> Create(Category category);
        Task<List<CategoryDto>> GetCategories();
        Task<CategoryDto> GetCategory(int id);
        Task<CategoryDto> Update(int id, Category category);
        Task Delete(int id);
    }
}
