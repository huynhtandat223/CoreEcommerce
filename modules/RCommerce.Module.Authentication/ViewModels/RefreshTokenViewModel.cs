using System.ComponentModel.DataAnnotations;

namespace RCommerce.Module.Authentication.ViewModels
{
    public class RefreshTokenModel
    {
        [Required]
        public string Token { get; set; }

        [Required]
        public string RefreshToken { get; set; }
    }
}
