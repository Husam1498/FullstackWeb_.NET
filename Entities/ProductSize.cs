using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProductSize
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public int SizeId { get; set; }
        public Sizes Size { get; set; }
    }
}
