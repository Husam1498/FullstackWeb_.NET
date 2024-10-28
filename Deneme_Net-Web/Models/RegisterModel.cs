using System.ComponentModel.DataAnnotations;

namespace Deneme_Net_Web.Models
{
    public class RegisterModel
    {

        public int K_id { get; set; }

        [Required(ErrorMessage ="Fullname Zorunludur!")]
        [MinLength(5,ErrorMessage ="En az 5 karakterden oluşmalıdır")]
        [MaxLength(25, ErrorMessage = "En fazla 25 karakterden oluşmalıdır")]
        public string Fullname { get; set; }

        [MinLength(4, ErrorMessage = "En az 4 Karakterden oluşmalıdır")]
        [MaxLength(12, ErrorMessage = "En fazla 12 Karakterden oluşmalıdır")]
        [Required(ErrorMessage = "Username Zorunludur!")]
        public string Username { get; set; }

        [MinLength(4, ErrorMessage = "En az 4 Karakterden oluşmalıdır")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password Zorunludur!")]
        public string Password { get; set; } 
        
        
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password Zorunludur!")]
        [Compare(nameof(Password),ErrorMessage ="Şifreniz eşleşmiyor")]
        public string RePassword { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email Zorunludur!")]
        public string Email { get; set; }
    }
}
