using System.Threading.Tasks;

namespace Bazar_App.Models.Interface
{
    public interface  IContact
    {
        Task<Contact> Create(Contact contact);
    }
}
