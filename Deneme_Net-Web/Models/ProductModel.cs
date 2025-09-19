using System.ComponentModel.DataAnnotations;

namespace Deneme_Net_Web.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Name alanı zorunludur")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Price alanı zorunludur")]
        public decimal Price { get; set; }
        [Required(ErrorMessage ="Description alanı zorunludur")]
        public string Description { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public string? Photo { get; set; }
        public string? Done { get; set; }

    }
}
