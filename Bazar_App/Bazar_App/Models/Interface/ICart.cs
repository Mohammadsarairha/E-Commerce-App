using Bazar_App.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bazar_App.Models.Interface
{
    public interface ICart
    {
        Task<CartDto> Create(Cart cart);
        Task<List<CartDto>> GetCarts();
        Task<CartDto> GetCart(int id);
        Task<CartDto> UpdateCart(int id, Cart newCart);
        Task Delete(int id);
        Task<CartDto> GetUserCart(string userId);
        Task AddProductToCart(int cartId, int productId);
        Task RemoveProductFromCart(int cartId, int productId);

    }
}
