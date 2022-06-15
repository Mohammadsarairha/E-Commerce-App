using System.ComponentModel.DataAnnotations;

namespace Bazar_App.Auth.Models.Dto
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}