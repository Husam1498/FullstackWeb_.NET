using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Photo
    {
        [Key] 
        public int PhotoId { get; set; }

        public string url { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
