using Bazar_App.Models;
using Bazar_App.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Bazar_App.Pages.Contacts
{
    public class IndexModel : PageModel
    {
        private readonly IContact _contact;

        public IndexModel(IContact contact)
        {
            _contact = contact;
        }

        public void OnGet()
        {

        }

        public async Task OnPost(string Name, string Email, string Subject , string Message)
        {
            Contact contact = new Contact
            {
                Name = Name,
                Email = Email,
                Subject = Subject,
                Message = Message
            };
            await _contact.Create(contact);

            ViewData["Message"] = "Thank for contacting us !";
        }
    }
}
