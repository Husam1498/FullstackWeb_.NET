using Entities;
using System.ComponentModel.DataAnnotations;

namespace Deneme_Net_Web.Models
{
    public class EditProductModel
    {
        public Guid ProductId { get; set; }


        [Required(ErrorMessage = "Name alanı zorunludur")]
        [MinLength(3, ErrorMessage = "En az 3 Karakterde isim Gİriniz")]
        [MaxLength(50, ErrorMessage = "En fazla 50 karakter giriniz")]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = "Price alanı zorunludur")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Description alanı zorunludur")]
        [MinLength(3, ErrorMessage = "En az 3 Karakterde isim Gİriniz")]
        public string? Description { get; set; }

        public string? Done { get; set; }


        [Required(ErrorMessage = "Category  alanı zorunludur")]
        public List<int>? SelectedCategoryIds { get; set; } = new List<int>();
        public List<Category>? Categories { get; set; }


        [Required(ErrorMessage = "Color  alanı zorunludur")]
        public List<int> SelectedColorIds { get; set; } = new List<int>();
        public List<Colors>? Colors { get; set; }

        [Required(ErrorMessage = "Size  alanı zorunludur")]
        public List<int>? SelectedSızeIds { get; set; } = new List<int>();
        public List<Sizes>? Sizes { get; set; }

        public List<IFormFile>? Files { get; set; } = new();

        public List<string>? FilesName { get; set; }
        public ICollection<Photo>? Photos { get; set; }
    }
}
