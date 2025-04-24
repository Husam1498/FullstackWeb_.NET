using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Sizes
    {
        [Key]
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public string  SizeShort { get; set; }

        //ilişkiler 
        public ICollection<ProductSize> ProductSizes { get; set; }
    }
}
