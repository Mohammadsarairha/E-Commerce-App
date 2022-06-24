using Bazar_App.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bazar_App.Models.Interface
{
    public interface ICheckout
    {
        Task<CheckoutDto> Create(Checkout checkout);
        Task<List<Checkout>> GetCheckouts();
        Task<Checkout> GetCheckout(int id);
        Task<Checkout> UpdateCheckout(int id, Checkout checkout);
        Task Delete(int id);
        Task<Checkout> GetCheckoutForUser(string userId, int cartId);
        bool GetUserCheckout(string userId, int cartId);
    }
}
