using System.ComponentModel.DataAnnotations;

namespace Bazar_App.Auth.Models.Dto
{
    public class LoginDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}