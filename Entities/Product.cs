using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public record Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public decimal Price { get; set; }
        public string   Description { get; set; }

        //ilişkiler
        public ICollection<ProductCategory> ProductCategories { get; set; }

        public ICollection<ProductSize> ProductSizes { get; set; }

        public ICollection<ProductColor> ProductColors { get; set; }

        public ICollection<Photo> Photos { get; set; }

    }
}
