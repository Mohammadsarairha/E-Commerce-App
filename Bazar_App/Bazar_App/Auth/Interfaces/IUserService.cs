using Bazar_App.Auth.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bazar_App.Auth.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> Register(RegisterDto registerDto, ModelStateDictionary modelstate);
        Task<UserDto> Authenticate(string username, string password);
        Task<UserDto> GetUser(ClaimsPrincipal principal);
        Task Logout();
    }
}