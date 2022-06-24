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
        Task UpdateCart(int id, Cart cart);
        Task Delete(int id);
        Task<CartDto> GetUserCart(string userId, int state);
        Task AddProductToCart(int cartId, int productId);
        Task RemoveProductFromCart(int cartId, int productId);
        Task RemoveCartProduct(int cartId, int productId);
        int GetProductQuantity(int cartId, int productId);
        bool GetCartById(int id);
        bool GetCartByUserId(string userId, int state);
    }
}
