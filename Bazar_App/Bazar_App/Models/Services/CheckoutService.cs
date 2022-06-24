using Bazar_App.Data;
using Bazar_App.Models.DTO;
using Bazar_App.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazar_App.Models.Services
{
    public class CheckoutService : ICheckout
    {
        private readonly BazaarDBContext _context;

        public CheckoutService(BazaarDBContext context)
        {
            _context = context;
        }
        public async Task<CheckoutDto> Create(Checkout checkout)
        {
            _context.Entry(checkout).State = EntityState.Added;
            await _context.SaveChangesAsync();

            CheckoutDto newCheckout = new CheckoutDto
            {
                Id = checkout.Id,
                Name = checkout.Name,
                Email = checkout.Email,
                Phone = checkout.Phone,
                Address = checkout.Address,
                City = checkout.City,
                State = checkout.State,
                Zip = checkout.Zip,
                UserId = checkout.UserId,
                CartId = checkout.CartId
            };
            return newCheckout;
        }
        public async Task<List<Checkout>> GetCheckouts()
        {
            return await _context.Checkout.ToListAsync();
        }
        public async Task<Checkout> GetCheckout(int id)
        {
            return await _context.Checkout.FindAsync(id);
        }
        public async Task<Checkout> UpdateCheckout(int id , Checkout checkout)
        {
            _context.Entry(checkout).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return checkout;
        }

        public bool GetUserCheckout(string userId, int cartId)
        {
            bool checkout =  _context.Checkout.Any(x => x.UserId == userId && x.CartId == cartId);

            return checkout;
        }

        public async Task<Checkout> GetCheckoutForUser(string userId , int cartId)
        {
            Checkout checkout = await _context.Checkout.Where(x => x.UserId == userId && x.CartId == cartId).FirstAsync();
            return checkout;
        }

        public async Task Delete(int id)
        {
            Checkout checkout = await GetCheckout(id);

            _context.Entry(checkout).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
