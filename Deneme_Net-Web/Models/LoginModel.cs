using System.ComponentModel.DataAnnotations;

namespace Deneme_Net_Web.Models
{
    public class LoginModel
    {
        public int İd { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]       
        public string Password { get; set; }

    }
}
