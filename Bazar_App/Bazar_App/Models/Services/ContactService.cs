using Bazar_App.Data;
using Bazar_App.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Bazar_App.Models.Services
{
    public class ContactService : IContact
    {
        private readonly BazaarDBContext _context;

        public ContactService(BazaarDBContext context)
        {
            _context = context;
        }

        public async Task<Contact> Create(Contact contact)
        {
            _context.Entry(contact).State = EntityState.Added;
            await _context.SaveChangesAsync();
            Contact newContact = new Contact
            {
                Name = contact.Name,
                Email = contact.Email,
                Subject = contact.Subject,
                Message = contact.Message
            };

            return newContact;
        }
    }
}
