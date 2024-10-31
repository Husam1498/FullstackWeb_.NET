using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Kullanicilar
    {
        [Key]
        public int K_id { get; set; }

        [MinLength(5)]
        [MaxLength(25)]
        public string Fullname { get; set; }

        [MinLength(4)]
        [MaxLength(12)]
        public string Username { get; set; }

        [MinLength(4)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Role { get; set; } = "user";

        [StringLength(100)]
        public string ProfilImageFileName { get; set; } = "noImg.png";
    }
}
