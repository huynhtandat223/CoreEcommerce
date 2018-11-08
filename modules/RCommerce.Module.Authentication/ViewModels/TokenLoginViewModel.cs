using System.ComponentModel.DataAnnotations;

namespace RCommerce.Module.Authentication.ViewModels
{
    public class TokenLoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
